using UnityEngine;

public class BulletMoveForward : MonoBehaviour 
{
    [SerializeField]
    private float acceleration = 50f;

    [SerializeField]
    private float initialVelocity = 5f;

    private Rigidbody2D rb;

    // Initialises the Rigidbody2D and sets the initial bullet velocity. 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * initialVelocity;
    }

    /// <summary>
    /// Applies continuous upward force for acceleration. 
    /// </summary>
    void Update()
    {
        rb.AddForce(Vector2.up * acceleration * Time.deltaTime);
    }
}
