using UnityEngine;
using System.Collections;

public class TranslationMovement : MonoBehaviour {

	private float low = -0.35f;
	private float high = 3.1f;
	private float step = 0.01f;

	private bool isUp = false;

	// Update is called once per frame <>
	void Update () {
		if (transform.position.x < low) {
			isUp = true;
		} else if (transform.position.x > high) {
			isUp = false;
		} 

		if (isUp) {
			transform.position = new Vector3 (transform.position.x + step, transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 (transform.position.x - step,transform.position.y,transform.position.z);
		}
	}
}
