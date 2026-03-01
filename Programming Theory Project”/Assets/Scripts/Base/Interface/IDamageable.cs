
public interface IDamageable
{
    // INTERFACE: The IDamageable interface defines a contract for any class that implements it, requiring them to provide an implementation for the TakeDamage method. This allows us to create a common interface for all damageable entities in the game (like characters, destructible objects, etc.) without needing to know the specific details of how they handle damage. By using an interface, we can ensure that any class that implements IDamageable can be treated as a damageable entity, allowing for greater flexibility and modularity in our code design.
    void TakeDamage(float damage); // Method to apply damage to the object
}
