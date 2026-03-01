using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Character Stats")]
    // Common properties for all characters
    // SerializeField allows us to set these values in the Unity Inspector
    // We use private fields with public getters to encapsulate the data and prevent external modification

    // ENCAPSULATION: By using private fields and public getters, we ensure that the internal state of the character cannot be modified directly from outside the class. This allows us to control how the character's health and speed are accessed and modified, ensuring that any changes to these properties go through defined methods (like TakeDamage) which can include additional logic (like checking for death).    
    [SerializeField] private float maxHealth = 100f; // Health of the character
    public float MaxHealth => maxHealth; // Public getter for max health
    [SerializeField] private float Speed = 5f; // Movement speed of the character
    public float speed => Speed; // Public getter for speed

    private float currentHealth;// Current health of the character
    public float CurrentHealth => currentHealth; // Public getter for current health


    // ABSTRACTION: The Character class is an abstract class that defines common properties and behaviors for all characters in the game. It abstracts away the specific details of how different types of characters (like Player, Enemy, NPC) will implement their own unique behaviors (like how they die) while providing a common interface for taking damage and managing health. This allows us to create different character types without worrying about the underlying implementation of health management, as they will all inherit from this base class and implement the Die method according to their specific needs.
    // Method to apply max health to the character
    protected virtual void Awake()
    {
        currentHealth = maxHealth; // Initialize current health to max health at the start
    }


    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reduce current health by the damage taken
        if (currentHealth <= 0)
        {
            Die(); // Call the Die method if health drops to zero or below
        }
    }

    
    protected abstract void Die(); // Abstract method to be implemented by subclasses for character death behavior


}
