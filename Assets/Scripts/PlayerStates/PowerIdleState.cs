/// <summary>
/// Player is ready to set the power of their shot.
/// </summary>
public class PowerIdleState : PlayerState
{
    public override void Execute()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
            player.StartPoweringUp();
    }
}
