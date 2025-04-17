 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveAndShoot : MonoBehaviour 
{
    // Movement direction. 
    private Vector2 movementDirection;

    // Local references. 
    private EngineBase engine;
    private WeaponBase weapon;

    private void Start() 
    {
        // Populate local references. 
        engine = GetComponent<EngineBase>();
        weapon = GetComponentInChildren<WeaponBase>();

        // Generate a downward-biased movement direction. 
        movementDirection = (Vector2.down + Random.insideUnitCircle * 0.5f).normalized;
    }

    private void FixedUpdate()
    {
        // Move the enemy if EnemyMovement is available. 
        if (engine != null)
        {
            engine.Move(movementDirection);
        }
    }

    // Update is called once per frame
    void Update () 
    {
        // Shoot if a WeaponBase/IWeapon component is attached. 
        if (weapon != null) 
        {
            weapon.Shoot();
        }
    }
}
