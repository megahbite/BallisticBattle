public class AIWaitingState : AIState
{
    private float targetAngle = 0f;

    public override void PhysicsExecute()
    {
        var currentAngle = ai.GetCurrentAngle();
        if (currentAngle < targetAngle)
            ai.SetCurrentAngle(currentAngle + 0.5f);
    }
}
