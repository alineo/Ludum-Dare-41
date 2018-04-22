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
                        if (Game.Level == 1) {
                            Debug.Log("Yay niveau 1 gagné !");
                            Game.LevelFinished = true;
                        }
                    // switch on/off the bedroom's light
                    } else if (c.gameObject.name == "switchBedRoomLamp") {
                         AnimatorSwitchLight.DoSwitchLight();

                        if (bedsideLampOn && Game.Level == 1) {
                            Debug.Log("Yay niveau 1 gagné !");
                            Game.LevelFinished = true;
                        }
                        else if (Game.Level == 2) {
                            Debug.Log("Yay niveau 2 gagné !");
                            Game.LevelFinished = true;
                        }
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
