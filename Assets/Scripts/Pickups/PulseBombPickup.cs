using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBombPickup : MonoBehaviour {

	Player player;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag.Equals("Player")){
			Destroy (gameObject);
			player = other.gameObject.GetComponent<Player> ();
			player.pulseBombCount += 1;
		}

	}
}
