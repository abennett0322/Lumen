using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour {

	GunController gunController;
	public Gun gun;

	void Awake() {
		gunController = GameObject.FindGameObjectWithTag ("Player").GetComponent<GunController>();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals("Player")){
			Destroy (gameObject);
			gunController.EquipGun (gun);
		}

	}
}
