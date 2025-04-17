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


        // Check if enough time has passed since the last shot. 
       /* if (currentTime - lastFiredTime > fireDelay) 
        {
            if (bullet == null || bulletSpawnPoint == null)
            {
                Debug.LogError("WeaponTripleShot: bullet or bulletSpawnPoint not assigned");
                return;
            }
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
                MoveConstantly move = newBullet.GetComponent<MoveConstantly>();
                if (move != null)
                {
                    move.Direction = new Vector2(xOffset + 0.5f * i, 0.5f);
                }
                else
                {
                    Debug.Log("WeaponTripleShot: Bullet prefab is missing MoveConstantly script!");
                }
            }*/

            // Update the last fired time. 
            lastFiredTime = currentTime;
        }
    }
}
