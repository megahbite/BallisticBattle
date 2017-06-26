public class PowerIdleState : PlayerState
{
    public override void Execute()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
            player.StartPoweringUp();
    }
}
