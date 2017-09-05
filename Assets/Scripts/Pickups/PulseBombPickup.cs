using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBombPickup : MonoBehaviour {


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals("Player")){
			Destroy (gameObject);
			PulseBombManager.pulseBombCount += 1;
		}

	}
}
