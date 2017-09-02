using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour {

	public float amplitude = 1;
	public float speed = 1;

	float yFloatPos;
	Vector3 floatPos;

	void Awake() {
		//yPos = transform.position.y;
		floatPos = transform.position;
		yFloatPos = floatPos.y;
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);

		floatPos.y = yFloatPos + amplitude * Mathf.Sin (speed * Time.time);
		transform.position = floatPos;
	}
}
