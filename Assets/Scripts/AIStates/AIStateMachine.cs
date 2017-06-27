using ByTheTale.StateMachine;
using UnityEngine;

/// <summary>
/// Manages the states for the AI's turn (AI used very, very loosely here).
/// </summary>
public class AIStateMachine : MachineBehaviour, IAIStateMachine
{
    public GameObject turret;

    public GameObject bulletPrefab;

    private Rigidbody2D turretRigidBody;

    public override void Start()
    {
        base.Start();
        if (turret == null || bulletPrefab == null) throw new MissingReferenceException("The turret or bulletPrefab variables have not been set with game objects");
        turretRigidBody = turret.GetComponent<Rigidbody2D>();
    }

    public override void AddStates()
    {
        AddState<AIWaitingState>();
        AddState<AIAimingState>();
        AddState<AIFiringState>();

        SetInitialState<AIWaitingState>();
    }

    public void FinishedAiming()
    {
        if (!IsCurrentState<AIAimingState>()) return;
        ChangeState<AIFiringState>();
    }

    public void FiringDone()
    {
        if (!IsCurrentState<AIFiringState>()) return;
        ChangeState<AIWaitingState>();
        var player = GameObject.FindGameObjectWithTag("Player");
        player.SendMessage("StartPlayersTurn");
    }

    public void StartAIsTurn()
    {
        if (!IsCurrentState<AIWaitingState>()) return;
        ChangeState<AIAimingState>();
    }

    public float GetCurrentAngle()
    {
        return turretRigidBody.rotation;
    }

    public void SetCurrentAngle(float angle)
    {
        turretRigidBody.MoveRotation(angle);
    }

    public void MakeBulletAndApplyForce(Vector2 forceVector)
    {
        var bulletClone = Instantiate(bulletPrefab, turret.transform);
        bulletClone.transform.localPosition = new Vector3(-0.7f, -0.18f);
        var bulletBody = bulletClone.GetComponent<Rigidbody2D>();
        bulletBody.AddForce(forceVector, ForceMode2D.Force);
    }
}
