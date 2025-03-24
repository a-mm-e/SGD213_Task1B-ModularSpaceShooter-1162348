using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovementScript playerMovementScript;
    private ShootingScript shootingScript;

    // Initialise references. 
    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovementScript>();
        shootingScript = GetComponent<ShootingScript>();
    }

    // Handle player input for movement and shooting. 
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Process horizontal movement input.
        if (horizontalInput != 0.0f)
        {
            playerMovementScript.HorizontalMovement(horizontalInput);
        }

        // Check if the player is pressing the fire button. 
        if (Input.GetButton("Fire1"))
        {
            shootingScript.Shoot();
        }
    }
}
