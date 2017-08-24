using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GunController gunController;
	public PulseBomb pulseBomb;

    void Awake()
    {
        gunController = GetComponent<GunController>();
    }

    void Update () {
		// Weapon input
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }

		if (Input.GetMouseButtonDown(1)) {
			Vector3 pulseBombLocation = transform.position;
			pulseBombLocation.y = 0;
			PulseBomb newPulseBomb = Instantiate (pulseBomb, pulseBombLocation, transform.rotation) as PulseBomb;
		}
	}
}
