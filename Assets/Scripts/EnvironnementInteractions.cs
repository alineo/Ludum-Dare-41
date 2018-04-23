using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementInteractions : MonoBehaviour
{

    Vector3 center;
    float radius = 5.0f;
    Collider[] hitColliders;

    // bedside lamp vars
    private bool bedsideLampOn = true;
    private GameObject bedsideLamp;

    private bool messageSwitchShown;
    
    void Start() {
        bedsideLamp = GameObject.Find("BedsideLampLight");
        switchLightBedsideLamps();
        messageSwitchShown = false;
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
                        if (Game.Level == 1 || Game.Level == 2) {
                            if (Game.Level == 1) Game.textInformationAnimation("Arg I still can't see..`\nI will go turn on the big light, I don't want to stay alone in the dark...");
                            else Game.textInformationAnimation("Wow, what is this giant robot ??\n It scares me...");
                            
                            switchLightBedsideLamps();
                        }
                    // switch on/off the bedroom's light
                    } else if (c.gameObject.name == "switchBedRoomLamp") {
                        if (Game.Level == 1 || Game.Level == 2) {
                            if (bedsideLampOn) {
                                Debug.Log("Yay niveau 1 ou 2 gagné !");
                                Game.finishLevel();
                            }
                        }
                    } else if (c.gameObject.name == "torchLamp") {
                        if (Game.player.getObjectCarriedName() == "pile") {
                            Game.finishLevel();

                            Debug.Log("gagné !");
                        }


                    } else if (c.gameObject.name == "bed") {
                        if (Game.LevelFinished)
                            Game.Win();
                    }
                }
            }
        }

        // message for when the player get close to the switch when it's very high
        if (Game.Level == 2 && !messageSwitchShown) {
            
            //Debug.Log("test");
            hitColliders = Physics.OverlapSphere(center, radius * 2);

            foreach (Collider c in hitColliders) {
                if (c.gameObject.tag == "LightSwitch") {
                    Game.textInformationAnimation("Why is the light switch so high ?\nI'll have to find something to climb to turn it on or to help me swith it on.");
                    messageSwitchShown = true;
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
