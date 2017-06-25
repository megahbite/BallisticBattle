using UnityEngine;

public interface IPlayerStateMachine
{
    #region Transitions
    void StartAiming();

    void AimingDone();

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
}