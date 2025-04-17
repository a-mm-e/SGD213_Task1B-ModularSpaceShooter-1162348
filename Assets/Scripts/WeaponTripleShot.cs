using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTripleShot : WeaponBase 
{
    /// <summary>
    /// Shoot will spawn three bullets, provided enough time has passed compared to our fireDelay.
    /// </summary>
    public override void Shoot() 
    {
        // Get the current time
        float currentTime = Time.time;

        if (currentTime - lastFiredTime > fireDelay)
        {
            Debug.Log("Shoot triple shot");

            //Angles for the three shots. 
            float[] angles = { -15f, 0f, 15f };
            // Horizontal position offset for each bullet. Adds separation. 
            float[] xOffsets = { -0.5f, 0f, 0.5f };

            for (int i = 0; i < angles.Length; i++)
            {
                // Rotation based on spread angle. 
                Quaternion rotationOffset = Quaternion.Euler(0, 0, angles[i]);
                // Position offset to prevent bullet clumping. 
                Vector3 spawnOffset = new Vector3(xOffsets[i], 0, 0);
                // Instantiate the bullet with new position offset and rotation. 
                Instantiate(bullet, bulletSpawnPoint.position + spawnOffset, transform.rotation * rotationOffset);
            }
    
           // Update the last fired time. 
            lastFiredTime = currentTime;
        }
    }
}
