using System.Collections;
using UnityEngine;


public class MoveForwardConstantly : MonoBehaviour
{

    [SerializeField]
    private float acceleration = 75f;

    [SerializeField]
    private float initialVelocity = 2f;

    private Rigidbody2D pickupRigidbody;

    // Initialise Rigidbody2D and set the initial velocity. 
    void Start()
    {
        pickupRigidbody = GetComponent<Rigidbody2D>();
        pickupRigidbody.linearVelocity = Vector2.down * initialVelocity; // Set inital downward velocity
    }

    // Update is called once per frame
    void Update()
    {
        // Apply force to move the object downwards. 
        Vector2 forceToAdd = Vector2.down * acceleration * Time.deltaTime;
        pickupRigidbody.AddForce(forceToAdd);
    }
}
