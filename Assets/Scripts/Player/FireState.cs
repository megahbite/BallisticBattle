using UnityEngine;

public class FireState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        player.MakeBulletAndApplyForce(CalculateFiringVector());
        player.FiringDone();
    }

    private Vector2 CalculateFiringVector()
    {
        var shotAngle = GameState.instance.currentPlayerAngle * Mathf.Deg2Rad;
        var power = 30f;
        var shotVectorX = Mathf.Cos(shotAngle) * power;
        var shotVectorY = Mathf.Sin(shotAngle) * power;
        return new Vector2(shotVectorX, shotVectorY);
    }
}
