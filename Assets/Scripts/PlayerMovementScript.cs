using System.Collections;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Expose movement speed to the Unity editor. This can be changed to public if needed in the future.
    [SerializeField]
    private float speed = 5000f;
    
    // The Rigidbody2D component. 
    private Rigidbody2D playerRigidbody;

    // Initialise references.
    void Start() 
    {
        // Get Rigidbody component once at the start of the game and store a reference to it.
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Handles horizontal movement.
    public void HorizontalMovement(float horizontalInput)
    {
        Vector2 forceToAdd = Vector2.right * horizontalInput * speed * Time.deltaTime;
        playerRigidbody.AddForce(forceToAdd);
    }
}
