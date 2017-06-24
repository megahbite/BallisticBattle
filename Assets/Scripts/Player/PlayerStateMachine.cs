using UnityEngine;
using System.Collections;
using ByTheTale.StateMachine;
using System;
using UnityEngine.UI;

public class PlayerStateMachine : MachineBehaviour, IPlayerStateMachine
{
    public GameObject turret;
    public GameObject angleText;

    public GameObject bullet;

    private Rigidbody2D turretRigidBody;

    public override void Start()
    {
        base.Start();
        if (turret == null || angleText == null) throw new MissingReferenceException("The turret or angleText variables have not been set with game objects");
        turretRigidBody = turret.GetComponent<Rigidbody2D>();
        SetCurrentAngle(0f);
    }

    public override void AddStates()
    {
        AddState<AimingIdleState>();
        AddState<AimingState>();
        AddState<PowerIdleState>();
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
        ChangeState<FireState>();
    }

    public void FiringDone()
    {
        if (!IsCurrentState<FireState>()) return;
        ChangeState<AimingIdleState>();
    }
    #endregion

    public void MakeBulletAndApplyForce(Vector2 forceVector)
    {
        var bulletClone = Instantiate(bullet, turret.transform);
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

        var text = angleText.GetComponent<Text>();
        if (text != null)
            text.text = string.Format("{0:f2}°", angle);
    }

    
}
