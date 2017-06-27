using UnityEngine;
using System.Collections;

public interface IAIStateMachine
{
    #region Transitions
    void FinishedAiming();
    void FiringDone();
    #endregion

    void MakeBulletAndApplyForce(Vector2 forceVector);

    float GetCurrentAngle();
    void SetCurrentAngle(float angle);
}
