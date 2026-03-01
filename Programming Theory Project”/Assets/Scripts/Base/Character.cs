using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
    [Header("Character Stats")]
    // Common properties for all characters
    // SerializeField allows us to set these values in the Unity Inspector
    // We use private fields with public getters to encapsulate the data and prevent external modification

    //--------- Health Properties with Encapsulation ---------//
    // ENCAPSULATION: By using private fields and public getters, we ensure that the internal state of the character cannot be modified directly from outside the class. This allows us to control how the character's health and speed are accessed and modified, ensuring that any changes to these properties go through defined methods (like TakeDamage) which can include additional logic (like checking for death).    
    [SerializeField] private float baseMaxHealth = 100f; // Health of the character
    protected virtual float MaxHealth => baseMaxHealth; // Public getter for max health


    //--------- Speed Property with Encapsulation and Polymorphism ---------//
    // ENCAPSULATION: The Speed property is defined as a virtual property that can be overridden by subclasses to provide specific speed values for different types of characters. This allows us to define a default speed in the base Character class while giving subclasses the flexibility to modify it as needed without affecting the overall structure of the code. By using a virtual property, we can ensure that any character that inherits from Character can have its own unique speed while still adhering to the common interface defined in the base class.

    [SerializeField] private float baseSpeed = 5f; // Movement speed of the character
    protected virtual float Speed => baseSpeed; // Public getter for speed


    //--------- Current Health with Encapsulation ---------//
    // ENCAPSULATION: The currentHealth field is private, meaning it cannot be accessed or modified directly from outside the Character class. Instead, we provide a public getter (CurrentHealth) to allow other classes to read the current health value without being able to change it. This ensures that the integrity of the character's health is maintained, as any changes to health must go through defined methods (like TakeDamage) that can include additional logic (such as checking for death or triggering events when health changes).
    private float currentHealth;// Current health of the character
    public float CurrentHealth => currentHealth; // Public getter for current health


    // ABSTRACTION: The Character class is an abstract class that defines common properties and behaviors for all characters in the game. It abstracts away the specific details of how different types of characters (like Player, Enemy, NPC) will implement their own unique behaviors (like how they die) while providing a common interface for taking damage and managing health. This allows us to create different character types without worrying about the underlying implementation of health management, as they will all inherit from this base class and implement the Die method according to their specific needs.
    // Method to apply max health to the character
    protected virtual void Awake()
    {
        currentHealth = MaxHealth; // Initialize current health to max health at the start
    }

    // Interface Implementation: The TakeDamage method is implemented as a virtual method in the Character class, allowing subclasses to override it if they need to provide specific behavior when taking damage (like playing a sound, triggering an animation, etc.). By providing a default implementation in the base class, we ensure that all characters will have a consistent way of handling damage while still allowing for customization in subclasses.
    // POLYMORPHISM: By marking the TakeDamage method as virtual, we allow subclasses to override this method to provide specific behavior when taking damage. This means that while all characters will have a default way of handling damage (reducing health and checking for death), individual character types can implement their own unique responses to taking damage (like playing different sounds, triggering different animations, or applying different effects). This use of polymorphism allows us to create a more dynamic and varied gameplay experience while still maintaining a consistent interface for damage handling across all character types.
    
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
