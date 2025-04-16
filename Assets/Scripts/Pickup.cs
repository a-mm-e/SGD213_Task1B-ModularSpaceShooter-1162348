using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pickup is an object aimed at passing weapon functionality to player objects. Depending on
/// the specified weaponType, the Pickup will tell the player object what object it should now
/// use as it's weapon.
/// </summary>
public class Pickup : MonoBehaviour
{
    [SerializeField]
    private WeaponType weaponType;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            HandlePlayerPickup(col.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandlePlayerPickup(player);
        }
    }

    /// <summary>
    /// HandlePlayerPickup handles all of the actions after a player has been collided with.
    /// It grabs the IWeapon component from the player, transfers all information to a
    /// new IWeapon (based on the provided weaponType).
    /// </summary>
    /// <param name="player"></param>
    private void HandlePlayerPickup(GameObject player)
    {
        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        // Handle a case where the player doesnt have a PlayerInput component. 
        if (playerInput == null) 
        {
            Debug.LogError("Player doesn't have a PlayerInput component.");
            return;
        } 
        //Swap weapon based on the weaponType
        playerInput.SwapWeapon(weaponType);

        //Destroy the pickup after use. 
        Destroy(gameObject);
    }

}

/// <summary>
/// WeaponType enumerates all possible weapons that can be picked up. 
/// </summary>
public enum WeaponType 
{ 
    machineGun, 
    tripleShot 
}
