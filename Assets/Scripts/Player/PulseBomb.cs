using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBomb : MonoBehaviour {

	public LayerMask enemyMask;
	public float maxSize = 15;
	public float growthRate = 1;
	public float fadeRate = .05f;

	float initialRadius;
	float currentRadius;
	float scale = 1;
	Color materialColor;

	void Awake() {
		materialColor = GetComponent<Renderer>().material.color;
		initialRadius = GetComponent <SphereCollider> ().radius;
		currentRadius = initialRadius;
	}

	void Update() {
		if (scale <= maxSize) {
			transform.localScale = Vector3.one * scale;
			GetComponent <SphereCollider>().radius = currentRadius;
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
		if (col.gameObject.layer == 10 && scale < 15){
			EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth> ();
			enemyHealth.Death (col.transform.position, col.transform.position - transform.position);
		}
	}
		
}
