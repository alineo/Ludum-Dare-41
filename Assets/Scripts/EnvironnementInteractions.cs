using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementInteractions : MonoBehaviour
{

    Vector3 center;
    float radius = 5.0f;
    Collider[] hitColliders;

    // bedside lamp vars
    private bool bedsideLampOn = false;
    private GameObject bedsideLamp;
    
    void Start() {
        bedsideLamp = GameObject.Find("BedsideLampLight");
    }

    void Update() {
        center = transform.position;
        hitColliders = Physics.OverlapSphere(center, radius);

        foreach(Collider c in hitColliders) {
            // an interactable object is nearby
            if (c.gameObject.tag == "interactable") {
                // an interraction is triggered with the nearby object
                if (Input.GetKeyDown("e")) {
                    // switch on/off the bedside's light
                    if (c.gameObject.name == "BedsideLamp") {
                        Debug.Log("Click lampe");
                        switchLightBedsideLamps();
                    // switch on/off the bedroom's light
                    } else if (c.gameObject.name == "switchBedRoomLamp") {
                         AnimatorSwitchLight.DoSwitchLight();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Switch on/off the bedside lamp's light
    /// </summary>
    private void switchLightBedsideLamps() {
        bedsideLampOn = !bedsideLampOn;
        bedsideLamp.SetActive(bedsideLampOn);
    }
}
