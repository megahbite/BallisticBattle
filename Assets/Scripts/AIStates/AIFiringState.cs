using UnityEngine;
using System.Collections;

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
        var shotVectorX = Mathf.Cos(shotAngle) * power * -1;
        var shotVectorY = Mathf.Sin(shotAngle) * power * -1;
        return new Vector2(shotVectorX, shotVectorY);
    }
}
