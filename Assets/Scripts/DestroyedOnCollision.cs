using UnityEngine;
using System.Collections.Generic;

public enum TagListType
{
    Blacklist,
    Whitelist
}

public class DestroyedOnCollision : MonoBehaviour
{
    [SerializeField]
    private TagListType tagListType = TagListType.Blacklist;

    [SerializeField]
    private List<string> tags = new List<string>();

    /// <summary>
    /// Handles collision logic based on tag filtering.
    /// Destroys the GameObject depending on Blacklist or Whitelist behaviour.
    /// </summary>
    /// <param name="other">The Collider2D that triggered this event.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        bool tagInList = tags.Contains(other.gameObject.tag);
        
        if ((tagListType == TagListType.Blacklist && tagInList) ||
                (tagListType == TagListType.Whitelist && !tagInList))
        {
            Destroy(gameObject);
        }
    }
}
