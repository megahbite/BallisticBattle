using UnityEngine;

/// <summary>
/// Player is ready to aim.
/// </summary>
public class AimingIdleState : PlayerState
{
    public override void Execute()
    {
        if (Input.GetMouseButtonDown(0))
            player.StartAiming();
    }
}
