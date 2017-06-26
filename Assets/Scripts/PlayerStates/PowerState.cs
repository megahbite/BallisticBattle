using UnityEngine;

public class PowerState : PlayerState
{
    public override void Execute()
    {
        if (Input.GetMouseButtonUp(0))
            player.PowerDone();
    }

    public override void PhysicsExecute()
    {
        var mousePosition = Input.mousePosition;
        var screenHeight = Camera.main.pixelHeight;
        var powerFraction = Mathf.Clamp(mousePosition.y / screenHeight, 0f, 1f);

        player.SetCurrentPower(powerFraction);
    }
}
