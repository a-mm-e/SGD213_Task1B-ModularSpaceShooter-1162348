using UnityEngine;
using System.Collections;

public class EnemyMoveForward : MonoBehaviour 
{
    [SerializeField]
    private float acceleration = 75f;

    [SerializeField]
    private float initialVelocity = 2f;

    private Rigidbody2D enemyRigidbody;

    // Initialise Rigidbody2D and set the initial velocity. 
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyRigidbody.linearVelocity = Vector2.down * initialVelocity; // Set inital downward velocity
    }

    // Update is called once per frame
    void Update()
    {
        // Apply force to move the enemy downwards 
        Vector2 forceToAdd = Vector2.down * acceleration * Time.deltaTime;
        enemyRigidbody.AddForce(forceToAdd);
    }
}
