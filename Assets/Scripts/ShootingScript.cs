using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float fireDelay = 1f;

    private float lastFiredTime = 0f;
    private float bulletOffset = 2f;

    void Start()
    {
        // Calculate bullet spawn offset based on object and bullet sizes.
        bulletOffset = GetComponent<Renderer>().bounds.extents.y + bullet.GetComponent<Renderer>().bounds.extents.y;
    }

    public void Shoot()
    {
        float currentTime = Time.time;

        // Ensure enough time has passed between shots.
        if (currentTime - lastFiredTime > fireDelay)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + bulletOffset);
            Instantiate(bullet, spawnPosition, transform.rotation);
            lastFiredTime = currentTime;
        }
    }
}
