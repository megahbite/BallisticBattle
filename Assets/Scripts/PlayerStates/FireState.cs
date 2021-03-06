﻿using UnityEngine;

/// <summary>
/// Player has set their state for this turn and is now firing.
/// </summary>
public class FireState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        player.MakeBulletAndApplyForce(CalculateFiringVector());
        player.FiringDone();
    }

    public Vector2 CalculateFiringVector()
    {
        var shotAngle = GameState.instance.CurrentPlayerAngle * Mathf.Deg2Rad;
        var power = GameState.instance.CurrentPlayerPower;
        var shotVectorX = Mathf.Cos(shotAngle) * power;
        var shotVectorY = Mathf.Sin(shotAngle) * power;
        return new Vector2(shotVectorX, shotVectorY);
    }
}
