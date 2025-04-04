using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMachineGun : WeaponBase 
{
    /// <summary>
    /// Shoot will spawn a new bullet, provided enough time has passed compared to our fireDelay.
    /// </summary>
    public override void Shoot()
    {
        // Get the current time
        float currentTime = Time.time;

        // If enough time has passed since our last shot compared to our fireDelay, spawn our bullet.
        if (currentTime - lastFiredTime > fireDelay) 
        {
            // Create the bullet at bulletSpawnPoint's position and weapon's rotation.
            // GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
            Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
            // Update the last fired time. 
            lastFiredTime = currentTime;
        }
    }
}
