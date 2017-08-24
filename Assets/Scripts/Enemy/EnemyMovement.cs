using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	Transform player;               // Reference to the player's position.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
	public float speed;

	EnemyAttack enemyAttack;

	float enemyColliderRadius;
	float playerColliderRadius;

    void Awake()
    {
        // Set up the references.
		player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
		nav.speed = speed;

		enemyAttack = GetComponent<EnemyAttack> ();

		enemyColliderRadius = GetComponent<CapsuleCollider> ().radius;
		playerColliderRadius = player.GetComponent<CapsuleCollider> ().radius;

		StartCoroutine (UpdatePath ());
    }

    void Update()
    {
	
    }

	// Optimize the pathfinding by updating every second rather than every frame
	IEnumerator UpdatePath() {
		float refreshRate = .25f;

		while(player != null) {
			nav.enabled = true;
			Vector3 dirToTarget = (player.position - transform.position).normalized;
			Vector3 targetPosition = player.position - dirToTarget * (enemyColliderRadius + playerColliderRadius + enemyAttack.attackDistanceThreshold / 2);
			// ... set the destination of the nav mesh agent to the player.
			nav.SetDestination (targetPosition);
			
			yield return new WaitForSeconds (refreshRate);

		}
	}
}
