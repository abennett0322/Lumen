using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;
	public ParticleSystem deathEffect;

    BoxCollider boxCollider;
	Light enemyLight;
	float timeBetweenFlash = .05f;
    bool isDead;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider> ();
		enemyLight = GetComponent<Light> ();

        currentHealth = startingHealth;
		DeactivateLight ();
    }

	public void TakeDamage(int amount, Vector3 hitPoint, Vector3 hitDirection)
    {
        if (isDead)
            return;

		if (currentHealth <= 0)
		{
			Death(hitPoint, hitDirection);
		}

        currentHealth -= amount;
		ActivateLight ();
    }

	void ActivateLight() {
		enemyLight.enabled = true;
		GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

		Invoke ("DeactivateLight", timeBetweenFlash);
	}

	void DeactivateLight() {
		enemyLight.enabled = false;
		GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
	}

	public void Death(Vector3 hitPoint, Vector3 hitDirection)
    {
        isDead = true;

        boxCollider.isTrigger = true;

		ScoreManager.score += scoreValue;

		Destroy(Instantiate (deathEffect.gameObject, hitPoint, Quaternion.FromToRotation (Vector3.forward, hitDirection)) as GameObject, deathEffect.startLifetime);

        Destroy(gameObject);
    }
}
