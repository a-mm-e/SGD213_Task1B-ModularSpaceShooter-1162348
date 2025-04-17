using UnityEngine;

/// <summary>
/// EngineBase is a universal movement controller that can be 
/// </summary>
public class EngineBase : MonoBehaviour
{
    // Acceleration of the game object. 
    [SerializeField]
    private float moveForce = 5000f;

    // Local references. 
    private Rigidbody2D rb;

    private void Start()
    {
        //Populate the Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Applies movement force in the given direction. 
    /// </summary>
    /// <param name="direction">A direction vector, expected to be a unit vector (magnitude of 1).</param>
    public void Move(Vector2 direction)
    {
        //Calculate the force to add.
        Vector2 force = direction * moveForce * Time.deltaTime;
        // apply forceToAdd to ourRigidbody
        rb.AddForce(force);
    }
}
