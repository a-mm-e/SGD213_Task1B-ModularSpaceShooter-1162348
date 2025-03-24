using UnityEngine;

public class SpawnOverTimeScript : MonoBehaviour
{
    // Object to spawn
    [SerializeField]
    private GameObject spawnObject;

    // Delay between spawns
    [SerializeField]
    private float spawnDelay = 2f;

    private Renderer ourRenderer;

    // Initialise and start the spawning process. 
    void Start()
    {
        ourRenderer = GetComponent<Renderer>();

        // Hide the spawner object (set the renderer inactive). 
        ourRenderer.enabled = false;

       // Start spawning objects at intervals. 
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    // Method to spawn objects randomly within the spawner's bounds. 
    void Spawn()
    {
        // Calculate the horizontal bounds for spawning. 
        float x1 = transform.position.x - ourRenderer.bounds.extents.x;
        float x2 = transform.position.x + ourRenderer.bounds.extents.x;

        // Randomly pick a point within these bounds. 
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Instantiate the object at the random spawn point. 
        Instantiate(spawnObject, spawnPoint, Quaternion.identity);
    }
}
