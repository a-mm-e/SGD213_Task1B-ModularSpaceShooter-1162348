using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    private int healingAmount = 10;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
       HandlePlayerPickup(col.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        HandlePlayerPickup(col.gameObject);
    }

    private void HandlePlayerPickup(GameObject player)
    {
        IHealth health = player.GetComponent<IHealth>();
        if (health == null)
        {
            Debug.LogError("Player does not implement IHealth. Tried on object:" + player.name);
            return;
        }

        health.Heal(healingAmount);
        Destroy(gameObject); //Remove the pickup after use. 
    }
}
