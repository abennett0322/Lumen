using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Transform[] muzzle;
    public Projectile projectile;
    public int damagePerShot = 20;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;

    float nextShotTime;

    public void Shoot()
    {
        if(Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
			for (int i = 0; i < muzzle.Length; i++) {
				Projectile newProjectile = Instantiate (projectile, muzzle[i].position, muzzle[i].rotation) as Projectile;
				newProjectile.SetSpeed (muzzleVelocity);
				newProjectile.SetDamage (damagePerShot);
				Destroy (newProjectile.gameObject, 2);
			}
        }
    }
}
