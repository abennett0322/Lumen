﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
	public ParticleSystem deathEffect;

	Material playerMaterial;
	Light playerLight;
	float timeBetweenFlash = .05f;
    bool isDead;

    void Awake()
    {
        currentHealth = startingHealth;
		playerMaterial = GetComponent<Renderer> ().material;
		playerLight = GetComponent<Light> ();
		DeactivateLight ();
    }  

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
		ActivateLight ();

        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

	void ActivateLight() {
		playerLight.enabled = true;
		playerMaterial.EnableKeyword ("_EMISSION");

		Invoke ("DeactivateLight", timeBetweenFlash);
	}

	void DeactivateLight() {
		playerLight.enabled = false;
		playerMaterial.DisableKeyword ("_EMISSION");
	}

    void Death()
    {
        isDead = true;

		Destroy(Instantiate (deathEffect.gameObject, transform.position, transform.rotation) as GameObject, deathEffect.main.startLifetime.constant);
		Destroy (gameObject);
    }
}
