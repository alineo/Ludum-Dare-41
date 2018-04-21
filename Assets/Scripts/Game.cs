﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    Player player;

    private GameObject hitObject;

	// Use this for initialization
	void Start () {
        player = new Player();
        hitObject = null;
    }
	
	// Update is called once per frame
	void Update () {
        // the player try to pick up or drop an object
        if (Input.GetKeyDown("r")) {
            Vector3 fwd = Camera.main.transform.rotation * Vector3.forward;
            
            RaycastHit hit;
            Ray ray = new Ray(transform.position, fwd);
            
            // an object was found in the raycast
            if (Physics.Raycast(ray, out hit, 2)) {
                // the player pick up the object
                hitObject = hit.collider.gameObject;
                //Debug.Log("Object " + hitObject.name + " found");

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
        } else if(Input.GetKeyDown("e")) {
            Vector3 fwd = Camera.main.transform.rotation * Vector3.forward;

            RaycastHit hit;
            Ray ray = new Ray(transform.position, fwd);

            // an object was found in the raycast
            if (Physics.Raycast(ray, out hit, 2)) {
                // the player pick up the object
                hitObject = hit.collider.gameObject;
                //Debug.Log("Object " + hitObject.name + " found");

                // the object found is pickable
                if (hitObject.tag == "interactable") {
                    Debug.Log("interactable object found");
                    //TODO: An information panel which inform that there is a nearby interactable object
                }
            }
            hitObject = null;
        }
    }
}