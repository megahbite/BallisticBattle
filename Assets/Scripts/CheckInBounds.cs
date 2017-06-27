using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If a bullet flies off the edge of the screen, just destroy it.
/// </summary>
public class CheckInBounds : MonoBehaviour {

    private void FixedUpdate()
    {
        if (transform.position.x > Camera.main.rect.xMax || transform.position.x < Camera.main.rect.xMin)
            Destroy(this);
    }
}
