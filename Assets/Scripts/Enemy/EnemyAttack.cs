using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
	public float attackDistanceThreshold = .5f;

    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
	PlayerMovement playerMovement;

	float enemyColliderRadius;
	float playerColliderRadius;
    float timer;
	float sqrDistToTarget;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth> ();
		playerMovement = player.GetComponent<PlayerMovement> ();
        enemyHealth = GetComponent<EnemyHealth> ();

		enemyColliderRadius = GetComponent<CapsuleCollider> ().radius;
		playerColliderRadius = player.GetComponent<CapsuleCollider> ().radius;

		sqrDistToTarget = (player.transform.position - transform.position).sqrMagnitude;
    }

    void Update()
    {
        timer += Time.deltaTime;


		if (player != null) {
			sqrDistToTarget = (player.transform.position - transform.position).sqrMagnitude;
		}

		if (timer >= timeBetweenAttacks && enemyHealth.currentHealth > 0 && sqrDistToTarget < Mathf.Pow (attackDistanceThreshold + enemyColliderRadius + playerColliderRadius, 2))
        {
			if (playerHealth.currentHealth > 0 && !playerMovement.dashing)
			{
				StartCoroutine(Attack());
				playerHealth.TakeDamage(attackDamage);
			}
        }
    }

	IEnumerator Attack()
    {
        timer = 0f;

		Vector3 originalPosition = transform.position;
		Vector3 dirToTarget = (player.transform.position - transform.position).normalized;
		Vector3 attackPosition = player.transform.position - dirToTarget * (enemyColliderRadius);

		float attackSpeed = 3;
		float percent = 0;

		while(percent <= 1){
			percent += Time.deltaTime * attackSpeed;
			float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
			transform.position = Vector3.Lerp (originalPosition, attackPosition, interpolation);

			yield return null;
		}
    }
}
