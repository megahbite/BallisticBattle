using UnityEngine;
using System.Collections;

public interface IAIStateMachine
{
    #region Transitions
    void FinishedAiming();
    void FiringDone();
    #endregion

    /// <summary>
    /// Spawn a bullet at the turret and apply the given force to it.
    /// </summary>
    /// <param name="forceVector">The force to apply to the spawned bullet.</param>
    void MakeBulletAndApplyForce(Vector2 forceVector);

    /// <summary>
    /// Gets the angle of the turret in the emplacement
    /// </summary>
    /// <returns>The angle of the turret in degrees.</returns>
    float GetCurrentAngle();

    /// <summary>
    /// Sets the angle of the turret in the emplacement
    /// </summary>
    /// <param name="angle">The angle to set the turret at, -90 being straight up. In degrees.</param>
    void SetCurrentAngle(float angle);
}
