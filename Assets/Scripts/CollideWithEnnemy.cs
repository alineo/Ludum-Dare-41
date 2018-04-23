using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideWithEnnemy : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player") {
            if (!Game.LevelFinished) {
                Game.Lose();
            }
        }
    }
}
