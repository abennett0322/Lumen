using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBombPickup : MonoBehaviour {

	public ParticleSystem pickupParticles;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals("Player")){
			Destroy(Instantiate (pickupParticles.gameObject, gameObject.transform.position, Quaternion.LookRotation(Vector3.up)) as GameObject, pickupParticles.main.startLifetime.constant);
			Destroy (gameObject);
			PulseBombManager.pulseBombCount += 1;
		}

	}
}
