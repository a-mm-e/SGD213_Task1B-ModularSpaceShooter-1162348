using System.Collections;
using UnityEngine;


/// <summary>
/// MoveConstantly gives an object the ability to continuously move based on the
/// specified direction, acceleration and initialVelocity variables.
/// </summary>
public class MoveConstantly : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 100f;

    [SerializeField]
    private float initialVelocity = 10f;

    [SerializeField]
    private Vector2 direction = new Vector2(0, 1); //Direction to move in. 

    // Local reference to the Rigidbody2D component. 
    private Rigidbody2D ourRigidbody;

    /// <summary>
    /// Direction provides access to the direction variable used to direct the movement of our object.
    /// It is expected that when setting the direction, the provided Vector2 is a unit vector. If not,
    /// it will be automatically normalised.
    /// </summary>
    public Vector2 Direction 
    {
        get 
        {
            return direction;
        }
        set 
        {
            if (value.magnitude == 1) 
            {
                direction = value;
            } 
            else 
            {
                direction = value.normalized;
            }
        }
    }

    void Start()
    {
        // Initialise the Rigidbody2D component and set the initial velocity. 
        ourRigidbody = GetComponent<Rigidbody2D>();
        ourRigidbody.linearVelocity = direction * initialVelocity; // Set initial velocity. 
    }

    void Update()
    {
        // Calculate our force to apply based on the current direction, acceleration, and delta time.
        Vector2 forceToAdd = direction * acceleration * Time.deltaTime;
        // Apply the force to the Rigidbody2D to continuously move the object.
        ourRigidbody.AddForce(forceToAdd);
    }
}
