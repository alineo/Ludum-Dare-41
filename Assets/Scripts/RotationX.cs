using UnityEngine;
using System.Collections;

public class RotationX : MonoBehaviour {

	public int speed;
	// Update is called once per frame
	void Update () {
		transform.Rotate (Time.deltaTime * speed,0,0, Space.World);
	}
}
