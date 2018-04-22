using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSwitchLight : MonoBehaviour {

    public GameObject animatorHolder;
    private static Animator anim;

    private static GameObject bedroomLamp;

    private static bool lightOn;

    void Start() {
        anim = animatorHolder.GetComponent<Animator>();
        lightOn = true;

        bedroomLamp = GameObject.Find("BedroomLampLight");
        
        DoSwitchLight(); // turn off the light at the beginning of the game
    }

    public static void DoSwitchLight() {
        lightOn = !lightOn;
        anim.SetBool("SwitchLightOn", lightOn);

        bedroomLamp.SetActive(lightOn);

        if (lightOn) {
            Debug.Log("Do switch Light On");
        } else {
            Debug.Log("Do switch Light Off");
        }
    }

    public static void TurnOnLight() {
        if (!lightOn) DoSwitchLight();
    }
}