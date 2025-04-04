using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveAndShoot : MonoBehaviour 
{
    // Movement direction. 
    private Vector2 movementDirection;

    // Local references. 
    private EnemyMovement enemyMovement;
    private WeaponBase weapon;

    private void Start() 
    {
        // Populate local references. 
        enemyMovement = GetComponent<EnemyMovement>();
        weapon = GetComponent<WeaponBase>();

        // Generate a downward-biased movement direction. 
        movementDirection = (Vector2.down + Random.insideUnitCircle * 0.5f).normalized;
    }

    private void FixedUpdate()
    {
        // Move the enemy if EnemyMovement is available. 
        if (enemyMovement != null)
        {
            enemyMovement.MoveEnemy(movementDirection);
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
