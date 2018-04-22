using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideWithEnnemy : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player") {
            if (!Game.LevelFinished) {
                Debug.Log("Joueur touché !");
                GameObject.Find("informationText").GetComponent<Text>().text = "Perdu !";
                Time.timeScale = 0f;
            }
        }
    }
}
