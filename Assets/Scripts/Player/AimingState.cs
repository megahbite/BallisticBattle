using UnityEngine;

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
        return Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
    }

    public override void Exit()
    {
        base.Exit();
        GameState.instance.currentPlayerAngle = player.GetCurrentAngle();
    }
}
