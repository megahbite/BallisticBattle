using UnityEngine;

/// <summary>
/// This would make testing state behaviour easier if I could get the Unity testing tools to work.
/// </summary>
public interface IPlayerStateMachine
{
    #region Transitions
    void StartAiming();

    void AimingDone();

    void StartPoweringUp();

    void PowerDone();

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
    /// <param name="angle">The angle to set the turret at, 90 being straight up. In degrees.</param>
    void SetCurrentAngle(float angle);

    /// <summary>
    /// Sets the power of the shot as a fraction of the maximum force.
    /// </summary>
    /// <param name="powerFraction">The fraction of the maximum to set the power at. From 0 to 1</param>
    void SetCurrentPower(float powerFraction);
}