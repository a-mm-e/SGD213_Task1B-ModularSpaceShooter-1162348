using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    protected int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField]
    protected int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    void Start()
    {
        currentHealth = maxHealth;
        UIManager.instance.UpdatePlayerHealthSlider((float)currentHealth / (float)maxHealth); //Ensure health bar is set up on game start. 
    }

    // <summary>
    /// Heal handles the functionality of receiving health
    /// </summary>
    /// <param name="healingAmount">The amount of health to gain, this value should be positive</param>
    public void Heal(int healingAmount)
    {
        Debug.Log("Player received health: " + healingAmount);
        currentHealth += healingAmount;
        //Prevent overhealing. 
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIManager.instance.UpdatePlayerHealthSlider((float)currentHealth / (float)maxHealth); // Update health slider. 
    }

    /// <summary>
    /// TakeDamage handles the functionality for taking damage
    /// </summary>
    /// <param name="damageAmount">The amount of damage to lose, this value should be positive</param>
    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Player took damage: " + damageAmount);
        currentHealth -= damageAmount;

        UIManager.instance.UpdatePlayerHealthSlider((float)currentHealth / (float)maxHealth); // Update health slider. 
        Debug.Log("Health updated on UI: " + currentHealth + "/" + maxHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    /// <summary>
    /// Handles all functionality related to when health reaches or goes below zero, should perform all necessary cleanup.
    /// </summary>
    public void Die()
    {
        Debug.Log("Player died. Destroying object... ");
        GetComponent<Renderer>().material.color = Color.red;
        Destroy(gameObject, 1f);
    }
}
