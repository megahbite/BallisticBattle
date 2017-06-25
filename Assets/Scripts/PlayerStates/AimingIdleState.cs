using UnityEngine;

public class AimingIdleState : PlayerState
{
    public override void Execute()
    {
        if (Input.GetMouseButtonDown(0))
            player.StartAiming();
    }
}
