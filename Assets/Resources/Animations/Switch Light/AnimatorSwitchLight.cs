using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSwitchLight : MonoBehaviour {

    public GameObject animatorHolder;
    private static Animator anim;
    static int switchOn = Animator.StringToHash("SwitchLightOn");
    static int switchOff = Animator.StringToHash("SwitchLightOff");

    private static bool lightOn;

    void Start() {
        anim = animatorHolder.GetComponent<Animator>();
        lightOn = false;
    }


    void Update() {
        /*float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space) && stateInfo.nameHash == runStateHash) {
            anim.SetTrigger(jumpHash);
        }*/
    }

    public static void DoSwitchLight() {

        lightOn = !lightOn;
        anim.SetBool("SwitchLightOn", lightOn);

        //AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (lightOn) {
            Debug.Log("Do switch Light On");
            //anim.Play("SwitchLightOn");
            //anim.SetTrigger(switchOn);
        } else {
            Debug.Log("Do switch Light Off");
            //anim.Play("SwitchLightOff");
            //anim.SetTrigger(switchOff);
        }
    }
}