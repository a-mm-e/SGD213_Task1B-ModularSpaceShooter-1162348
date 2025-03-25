using UnityEngine;

public class DestroyedOnExit : MonoBehaviour
{
    /// <summary>
    /// Called when the object leaves the viewport
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
