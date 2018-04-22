using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementInteractions : MonoBehaviour
{

    Vector3 center;
    float radius;
    Collider[] hitColliders;



    void Update()
    {
        center = transform.position;
        hitColliders = Physics.OverlapSphere(center, radius);

        foreach(Collider c in hitColliders) {
            if (c.gameObject.name == "BedsideLamp") {/*Debug.Log("Lamp");*/}
        }
    }
}
