using UnityEngine;

public interface IPlayerStateMachine
{
    #region Transitions
    void StartAiming();

    void AimingDone();

    void StartPoweringUp();

    void PowerDone();

    void FiringDone();
    #endregion

    void MakeBulletAndApplyForce(Vector2 forceVector);

    /// <summary>
    /// Gets the angle of the turret in the emplacement
    /// </summary>
    /// <returns>The angle of the turret in degrees.</returns>
    float GetCurrentAngle();

    /// <summary>
    /// Sets the angle of the turret in the emplacement
    /// </summary>
    /// <param name="angle">The angle to set the turret at, pi/2 being straight up. In degrees.</param>
    void SetCurrentAngle(float angle);

    /// <summary>
    /// Sets the power of the shot as a fraction of the maximum force.
    /// </summary>
    /// <param name="powerFraction">The fraction of the maximum to set the power at. From 0 to 1</param>
    void SetCurrentPower(float powerFraction);
}