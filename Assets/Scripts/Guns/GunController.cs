using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public Transform weaponHold;                // The location the gun will be equipped to the gameObject.
    public Gun startingGun;                     // The gun the gameObject will start with.
    public Gun equippedGun;                            // Variable to store the currently equipped gun.

    void Awake()
    {
        // Equip the starting gun on awake
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    public void EquipGun(Gun gunToEquip)
    {
        // Remove the currently equipped gun if there is one.
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }

        // equip the gun to the gameObject at the weapon hold location.
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;

        // make the gun a child of the gameObject's weaponHold location so the gun moves with the object holding it.
        equippedGun.transform.parent = weaponHold;
    }

    public void Shoot()
    {
        if (equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}
