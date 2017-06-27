/// <summary>
/// Move the AI's turret back down to the resting position and wait for next turn.
/// </summary>
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
