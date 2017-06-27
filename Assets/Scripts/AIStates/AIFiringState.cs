using UnityEngine;
using System.Collections;

/// <summary>
/// AI is firing after moving to the angle.
/// </summary>
public class AIFiringState : AIState
{
    public override void Enter()
    {
        base.Enter();
        ai.MakeBulletAndApplyForce(CalculateFiringVector());
        ai.FiringDone();
    }

    public Vector2 CalculateFiringVector()
    {
        var shotAngle = ai.GetCurrentAngle() * Mathf.Deg2Rad;
        var power = Random.Range(50, 70); // Optimal is around 60 at 45 degrees so this is hopefully fair-ish
        // Our angles are negative as we're facing backwards so swap trig functions
        var shotVectorX = Mathf.Sin(shotAngle) * power; 
        var shotVectorY = Mathf.Cos(shotAngle) * power;
        return new Vector2(shotVectorX, shotVectorY);
    }
}
