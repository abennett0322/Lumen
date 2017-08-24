using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public LayerMask shootableMask;
    public LayerMask enemyMask;
	public float timeBetweenHitFlashes = 0.5f;
    float speed = 10;
    int damagePerShot = 20;

    void Awake()
    {
        
    }

    void Update () {
		float moveDistance = speed * Time.deltaTime;

		CheckCollisions (moveDistance);

		transform.Translate(Vector3.forward * moveDistance);
	}

	void CheckCollisions(float moveDistance) {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, moveDistance, shootableMask, QueryTriggerInteraction.Collide)) {
			OnHitObject (hit);
		}

        if (Physics.Raycast(ray, out hit, moveDistance, enemyMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
            OnHitEnemy(hit);
        }
	}

	void OnHitObject(RaycastHit hit) {

		GameObject.Destroy (gameObject);
	}

    void OnHitEnemy(RaycastHit hit)
    {
        EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

		if (enemyHealth != null)
		{
			enemyHealth.TakeDamage(damagePerShot, hit.point, transform.forward);
        }  
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetDamage(int newDamagePerShot)
    {
        damagePerShot = newDamagePerShot;
    }
}
