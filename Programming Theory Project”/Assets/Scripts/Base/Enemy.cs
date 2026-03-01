using UnityEngine;

public abstract class Enemy : Character
{
  
    [Header("Enemy Stats")]
    protected override float Speed => base.Speed * 2f;// Override the speed for enemies to be faster than the base character speed

   private Transform player; // Reference to the player
   protected Transform Player => player; // Property to access the player transform


    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player in the scene by tag
    }

    
    protected virtual void Update()
    {
        // ENCAPSULATION: The MoveTowardsPlayer method is encapsulated within the Enemy class, meaning that the logic for how the enemy moves towards the player is contained within this class. This allows us to modify the movement behavior of the enemy without affecting other parts of the code, as any changes to how the enemy moves will only require changes within this method. By calling MoveTowardsPlayer in the Update method, we ensure that the enemy continuously moves towards the player every frame, while keeping the movement logic organized and contained within the Enemy class.
        MoveTowardsPlayer(); // Move towards the player every frame
    }


    // Method to move the enemy towards the player
    // ABSTRACTION: The MoveTowardsPlayer method abstracts away the specific details of how the enemy moves towards the player. It calculates the direction towards the player and updates the enemy's position accordingly, without exposing the underlying implementation to other parts of the code. This allows us to change how the enemy moves (for example, by adding obstacles or changing movement patterns) without affecting other classes that interact with the enemy, as they will still call MoveTowardsPlayer without needing to know how it works internally.
    protected virtual void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized; // Calculate direction towards the player
            transform.position += direction * Speed * Time.deltaTime; // Move the enemy towards the player
        }

    }


    protected override void Die()
    {
        // TODO: Implement enemy death behavior
        Destroy(gameObject);
    }


}