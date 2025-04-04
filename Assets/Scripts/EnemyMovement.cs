using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyMovement handles all of the movement specifc state and behaviour for the enemy.
/// </summary>
public class EnemyMovement : MonoBehaviour 
{
    // enemyAcceleration indicates how fast the enemy accelerates.
    [SerializeField]
    private float enemyAcceleration = 5000f;

    // Local reference to the enemy's Rigidbody2D component. 
    private Rigidbody2D enemyRigidbody;

    void Start() 
    {
        // Initialise Rigidbody2D reference. 
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Moves the enemy by applying a force based on the provided direction. 
    /// </summary>
    /// <param name="horizontalInput">A direction vector, expected to be a unit vector (magnitude of 1).</param>
    public void MoveEnemy(Vector2 direction) 
    {
        // Calculate the force to apply based on the direction, acceleration, and delta time. 
        Vector2 forceToAdd = direction * enemyAcceleration * Time.deltaTime;
        // Apply the calculated force to the Rigidbody2D. 
        enemyRigidbody.AddForce(forceToAdd);
    }
}
