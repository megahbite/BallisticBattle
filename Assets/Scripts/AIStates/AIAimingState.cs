public class AIAimingState : AIState
{
    private float targetAngle = -45f;

    public override void PhysicsExecute()
    {
        var currentAngle = ai.GetCurrentAngle();
        if (currentAngle > targetAngle)
            ai.SetCurrentAngle(currentAngle - 0.3f);
        else
            ai.FinishedAiming();
    }
}
