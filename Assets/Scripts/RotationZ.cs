using UnityEngine;
using System.Collections;

public class RotationZ : MonoBehaviour {

	public int speed;
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,Time.deltaTime * speed, Space.World);
	}
}
