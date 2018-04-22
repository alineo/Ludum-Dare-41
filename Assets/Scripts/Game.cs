﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static Player player;
    
    private GameObject hitObject;

    private GameObject robot;
    private GameObject witch;

    private GameObject pile;
    private GameObject torchLamp;

    private RaycastHit hit;
    private Ray ray;
    private Vector3 fwd;

    public static int Level;

    public static bool LevelFinished = false;
    
    // Use this for initialization
    void Start () {
        player = new Player();
        hitObject = null;
        Level = PlayerPrefs.GetInt("Level");
        Debug.Log("Commencement du niveau " + Level);

        robot = GameObject.Find("Robot");
        //witch = GameObject.Find("witch");
        robot.SetActive(false);
        //witch.SetActive(false);
        
        pile = GameObject.Find("Pile");
        pile.SetActive(false);

        torchLamp = GameObject.Find("TorchLamp");
        torchLamp.SetActive(false);
        
        // place the objects for the right level design
        if (Level == 2) { // robot
            Vector3 pos = GameObject.Find("LightSwitch").transform.position;
            GameObject.Find("LightSwitch").transform.position = new Vector3(pos.x, pos.y + 3, pos.z);
            robot.SetActive(true);
        }
        else if (Level  == 3) { // witch
            pile.SetActive(true);
            torchLamp.SetActive(true);
            GameObject.Find("BedsideLamp").transform.gameObject.tag = "Untagged";

            robot.SetActive(true);
            //witch.SetActive(true);
        }
        else if (Level == 4) { // witch and robot
            robot.SetActive(true);
            //witch.SetActive(true);
        }
        else if (Level == 5) {
            //TODO: Activate the lava
        }
    }

    // Update is called once per frame
    void Update () {
        // the player try to pick up or drop an object
        if (Input.GetKeyDown("r")) {
            fwd = Camera.main.transform.rotation * Vector3.forward;
            
            ray = new Ray(transform.position, fwd);
            
            // an object was found in the raycast
            if (Physics.Raycast(ray, out hit, 3)) {
                // the player pick up the object
                hitObject = hit.collider.gameObject;
                Debug.Log("Object " + hitObject.name + " found");

                // the object found is pickable
                if (hitObject.tag == "pickable") {
                    Debug.Log("pickable object found");
                    if (player.pickObject(hitObject)) {
                        hitObject.SetActive(false);
                        Debug.Log("Object : " + hitObject.name + " picked up");
                    }
                }
            } else {
                if (player.hasObject()) {
                    // drop object
                    hitObject = player.dropObject();
                    if (hitObject != null) {
                        Debug.Log("Object dropped");
                        hitObject.transform.position = Camera.main.transform.rotation * Vector3.forward*2 + Camera.main.transform.position;
                    }
                }
            }
            hitObject = null;
        }
    }
}
