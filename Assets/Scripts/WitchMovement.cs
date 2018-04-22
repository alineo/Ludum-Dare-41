using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMovement : MonoBehaviour {

    private float low = 0.2f;
    private float high = 0.85f;
    private float step = 0.008f;

    private bool isUp = false;

    // Update is called once per frame <>
    void Update() {
        if (transform.position.y < low) {
            isUp = true;
        }
        else if (transform.position.y > high) {
            isUp = false;
        }

        if (isUp) {
            transform.position = new Vector3(transform.position.x, transform.position.y + step, transform.position.z);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y - step, transform.position.z);
        }
    }
}
