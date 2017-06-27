using UnityEngine;

/// <summary>
/// Player is currently aiming
/// </summary>
public class AimingState : PlayerState
{
    public override void Execute()
    {
        if (Input.GetMouseButtonUp(0))
            player.AimingDone();
    }

    public override void PhysicsExecute()
    {
        var mousePosition = Input.mousePosition;

        player.SetCurrentAngle(CalculateAngle(mousePosition));
    }

    public static float CalculateAngle(Vector3 mousePosition)
    {
        // The player is close enough to the bottom left corner of the screen ([0,0] in screen space)
        // that finding theta of the mouse vector is good enough without needing to translate to world space.
        return Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
    }
}
