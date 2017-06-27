using System;
using ByTheTale.StateMachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MachineBehaviour, IPlayerStateMachine
{
    public GameObject turret;

    public GameObject bulletPrefab;

    public float maxPower = 70;

    private Rigidbody2D turretRigidBody;

    public override void Start()
    {
        base.Start();
        if (turret == null || bulletPrefab == null) throw new MissingReferenceException("The turret or bulletPrefab variables have not been set with game objects");
        turretRigidBody = turret.GetComponent<Rigidbody2D>();
        SetCurrentAngle(0f);
        GameState.instance.HighlightAngle();
    }

    public override void AddStates()
    {
        AddState<AimingIdleState>();
        AddState<AimingState>();
        AddState<PowerIdleState>();
        AddState<PowerState>();
        AddState<FireState>();
        AddState<WaitingState>();

        SetInitialState<AimingIdleState>();
    }

    #region Transitions
    public void StartAiming()
    {
        if (!IsCurrentState<AimingIdleState>()) return;
        ChangeState<AimingState>();
    }

    public void AimingDone()
    {
        if (!IsCurrentState<AimingState>()) return;
        GameState.instance.HighlightPower();
        ChangeState<PowerIdleState>();
    }

    public void StartPoweringUp()
    {
        if (!IsCurrentState<PowerIdleState>()) return;
        ChangeState<PowerState>();
    }

    public void PowerDone()
    {
        if (!IsCurrentState<PowerState>()) return;
        ChangeState<FireState>();
    }

    public void FiringDone()
    {
        if (!IsCurrentState<FireState>()) return;
        GameState.instance.HighlightAngle();
        ChangeState<WaitingState>();
        var ai = GameObject.FindGameObjectWithTag("AI");
        ai.SendMessage("StartAIsTurn");
    }

    public void StartPlayersTurn()
    {
        if (!IsCurrentState<WaitingState>()) return;
        ChangeState<AimingIdleState>();
    }
    #endregion

    public void MakeBulletAndApplyForce(Vector2 forceVector)
    {
        var bulletClone = Instantiate(bulletPrefab, turret.transform);
        bulletClone.transform.localPosition = new Vector3(0.7f, -0.18f);
        var bulletBody = bulletClone.GetComponent<Rigidbody2D>();
        bulletBody.AddForce(forceVector, ForceMode2D.Force);
    }

    public float GetCurrentAngle()
    {
        return turretRigidBody.rotation;
    }

    
    public void SetCurrentAngle(float angle)
    {
        var hinge = turret.GetComponent<HingeJoint2D>();
        var angleConstraints = hinge.limits;

        if (angle < angleConstraints.min) angle = angleConstraints.min;
        if (angle > angleConstraints.max * -1) angle = angleConstraints.max * -1;

        turretRigidBody.MoveRotation(angle);
        GameState.instance.CurrentPlayerAngle = angle;
    }

    public void SetCurrentPower(float powerFraction)
    {
        GameState.instance.CurrentPlayerPower = powerFraction * maxPower;
    }
}
