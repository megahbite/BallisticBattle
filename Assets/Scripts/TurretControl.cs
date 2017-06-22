using UnityEngine;
using UnityEngine.UI;

public class TurretControl : MonoBehaviour {

    public GameObject turret;
    public GameObject angleText;

    private void Start()
    {
        if (turret == null || angleText == null) throw new MissingReferenceException("The turret or angleText variables have not been set with game objects");
        SetTurretRotation(0f);
    }

    private void FixedUpdate()
    {
        if (!Input.GetMouseButton(0)) return;
        var mousePosition = Input.mousePosition;

        SetTurretRotation(Mathf.Atan2(mousePosition.y, mousePosition.x));
    }

    /// <summary>
    /// Sets the angle of the turret in the emplacement
    /// </summary>
    /// <param name="angle">The angle to set the turret at, pi/2 being straight up. In radians.</param>
    private void SetTurretRotation(float angle)
    {
        var turretRigidBody = turret.GetComponent<Rigidbody2D>();
        var hinge = turret.GetComponent<HingeJoint2D>();
        var angleConstraints = hinge.limits;

        var degrees = Mathf.Rad2Deg * angle;

        if (degrees < angleConstraints.min) degrees = angleConstraints.min;
        if (degrees > angleConstraints.max * -1) degrees = angleConstraints.max * -1;

        turretRigidBody.MoveRotation(degrees);

        var text = angleText.GetComponent<Text>();
        if (text != null)
            text.text = string.Format("{0:f2}°", degrees);
    }
}
