using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBomb : MonoBehaviour {

	public LayerMask enemyMask;
	public float maxSize = 25;
	public float growthRate = 1;
	public float fadeRate = .05f;

	float scale = 1;
	Color materialColor;

	void Awake() {
		materialColor = GetComponent<Renderer>().material.color;
	}

	void Update() {
		if (scale <= maxSize) {
			transform.localScale = Vector3.one * scale;
			scale += growthRate * Time.deltaTime;
		} else {
			materialColor.a -= fadeRate;
			GetComponent<Renderer> ().material.color = materialColor;
		}


		if (scale > maxSize && materialColor.a < 0){
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == 10 && scale < maxSize){
			EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth> ();
			enemyHealth.Death (col.transform.position, col.transform.position - transform.position);
		}
	}
		
}
