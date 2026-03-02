using UnityEngine;

public class Player : Character
{
    [Header("Player Stats")]
    // Additional properties specific to Player can be added here
    [SerializeField] private float playerHealth = 120f; // Override the base max health for the player
    protected override float MaxHealth => playerHealth; // Override the max health for the player

    [SerializeField] private float playerSpeed = 6f; // Override the base speed for the player
    // Override the Speed property if you want to set a specific speed for the player, otherwise it will use the base speed defined in Character
    protected override float Speed => playerSpeed; // Use the player-specific speed

    protected override void Die()
    {
        // Implement player death behavior here (e.g., play animation, disable controls, etc.)
        Debug.Log("Player has died!");
        // For example, we could disable the player GameObject
        gameObject.SetActive(false);
    }

}
