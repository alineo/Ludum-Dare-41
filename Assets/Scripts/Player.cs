using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    private GameObject objectCarried;

    public Player() {
        objectCarried = null;
    }

    public bool pickObject(GameObject obj) {
        if (objectCarried != null) return false;
        objectCarried = obj;
        return true;
    }

    public GameObject dropObject() {
        GameObject obj = objectCarried;
        objectCarried.SetActive(true);
        objectCarried = null;
        return obj;
    }

    public bool hasObject() {
        return objectCarried != null;
    }
}
