using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectorInteractable : MonoBehaviour {

    private List<GameObject> objects;

    void Start() {
        objects = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other) {
        if (Game.Level == 4) { // only for the 4th level
            if (!objects.Contains(other.gameObject)) {
                Debug.Log("Ajout de " + other.gameObject.name + " dans la liste trigger");
                objects.Add(other.gameObject);
                if (objects.Count >= 9) {
                    Debug.Log("9 objets rangés ! C'est gagné !");
                    Game.finishLevel();
                }
            }
        }
    }
}
