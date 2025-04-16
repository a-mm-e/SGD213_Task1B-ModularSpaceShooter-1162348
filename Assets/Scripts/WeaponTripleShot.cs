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

        // Check if enough time has passed since the last shot. 
        if (currentTime - lastFiredTime > fireDelay) 
        {
            //Debug log for triple shot.
            print("Shoot triple shot");

            // Offset for bullet directions. 
            float xOffset = -0.5f;

            // Create 3 bullets, each with a slightly different direction. 
            for (int i = 0; i < 3; i++) 
            {
                // Instantiate bullet at the spawn point and weapon's rotation. 
                GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
                // Set the direction for the bullet. 
                newBullet.GetComponent<MoveConstantly>().Direction = new Vector2(xOffset + 0.5f * i, 0.5f);
            }

            // Update the last fired time. 
            lastFiredTime = currentTime;
        }
    }
}
