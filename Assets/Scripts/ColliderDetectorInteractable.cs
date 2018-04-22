using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectorInteractable : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }
}
