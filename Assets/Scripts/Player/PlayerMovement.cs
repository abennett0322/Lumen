using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;            	// The speed the player will move at.
	public GameObject weaponLocation;		// The location of the weapon the player is holding.
	public GunController gun;				// Reference to the GunController script.

    float dashSpeed = 1f;       			// The speed the player will dash at.
	int dashTime = 0;						
    public bool dashing = false;

	Vector3 movement;					// The vector to store the direction of the players movement.
	Rigidbody playerRigidbody;			// Reference to the player's rigidbody.
	ParticleSystem dashEffect;			// Reference to the player's dash particle effect.
	int floorMask;						// A layer mask so that a ray can be cast just at gameobjects on the floor level.
	float camRayLength = 100f;			// The lenght of the ray from the camera into the scene.

	void Awake() {
		// Create a layer mask for the floor.
		floorMask = LayerMask.GetMask ("Floor");

		// Set up references.
		playerRigidbody = GetComponent<Rigidbody> ();
		dashEffect = GetComponentInChildren<ParticleSystem> ();

	}

	void FixedUpdate() {
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		// Turn the player to face the mouse curser.
		Turning ();

		// Move the player around the scene.
		Move (h, v);

		// if the dash timer is above zero, set the dashSpeed and decreaase the timer.
		if (dashTime > 0){
			dashSpeed = 10f;
			dashTime--;
		}

		// after the dash timer is complete, set the speed back to normal and stop the dash effect.
		if (dashTime == 0) {
			dashing = false;
			dashSpeed = 1;
			dashEffect.Stop ();
		}
	}

    void Update()
    {
        // Use the Dash ability by pressing down the space bar.
        if (Input.GetKeyDown("space"))
        {
            dashing = true;
			dashEffect.Play ();
			dashTime = 8;
		}
    }

    void Move (float h, float v) {
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * dashSpeed * Time.deltaTime;

		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);

    }

	void Turning() {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;

        // Perform the raycast, and if it hits something on the floor layer...
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			
			if (gun.equippedGun.muzzle.Length == 1) {
				// Create a vector from the gun to the point on the floor the raycast from the mouse hit.
				Vector3 gunToMouse = floorHit.point - weaponLocation.transform.position;

				// Ensure the vector is entirely along the floor plane.
				gunToMouse.y = 0f;

				// Create a quaternion (rotation) based on looking down the vector from the gun to the mouse.
				Quaternion gunRotation = Quaternion.LookRotation (gunToMouse);

				// Set the player's rotation to this new rotation.
				playerRigidbody.MoveRotation (gunRotation);

			} else {
				// Create a vector from the player to the point on the floor the raycast from the mouse hit.
				Vector3 playerToMouse = floorHit.point - transform.position;

				// Ensure the vector is entirely along the floor plane.
				playerToMouse.y = 0f;

				// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
				Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

				// Set the player's rotation to this new rotation.
				playerRigidbody.MoveRotation (newRotation);

			}
		}
	}

}
