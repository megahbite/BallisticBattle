using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInBounds : MonoBehaviour {

    private void FixedUpdate()
    {
        if (transform.position.x > Camera.main.rect.xMax)
            Destroy(this);
    }
}
