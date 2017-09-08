using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour {

	GunController gunController;
	public Gun gun;
	public ParticleSystem pickupParticles;

	void Awake() {
		gunController = GameObject.FindGameObjectWithTag ("Player").GetComponent<GunController>();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals("Player")){
			Destroy(Instantiate (pickupParticles.gameObject, other.transform.position, Quaternion.LookRotation(Vector3.up)) as GameObject, pickupParticles.main.startLifetime.constant);
			Destroy (gameObject);
			gunController.EquipGun (gun);
			gunController.gunPickupTimer = 15f;
		}

	}
}
