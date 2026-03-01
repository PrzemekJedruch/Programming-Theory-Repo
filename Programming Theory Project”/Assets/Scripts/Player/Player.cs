using UnityEngine;

public class Player : Character
{
    // Override the Speed property if you want to set a specific speed for the player, otherwise it will use the base speed defined in Character
    protected override float Speed => base.Speed; // Use the base speed defined in Character, can be overridden for player-specific speed if needed



    private void Update()
    {
        MoveFunction(); // Call the movement function in the Update method to handle player movement every frame
    }
   
    // ENCAPSULATION: The MoveFunction method is a private method that handles the player's movement logic. By keeping this method private, we ensure that the movement logic is encapsulated within the Player class and cannot be accessed or modified directly from outside the class. This allows us to control how the player moves and ensures that any changes to the movement logic are made in a controlled manner within the Player class itself. The MoveFunction uses the Speed property defined in the Character class to determine how fast the player should move, demonstrating how we can utilize inheritance and polymorphism to create specific behaviors for different character types while still adhering to a common interface defined in the base class.
    // ABSTRACTION: The MoveFunction abstracts away the specific details of how the player moves, allowing us to focus on the high-level behavior of player movement without worrying about the underlying implementation. This means that we can change the way the player moves (e.g., using a different input method or adding additional movement mechanics) without affecting other parts of the code that rely on the player's movement behavior, as long as we maintain the same interface for how movement is handled within the Player class.
    // POLYMORPHISM: By using the Speed property from the Character class, we can easily modify the player's movement speed by overriding the Speed property in the Player class if needed. This allows us to have different types of characters (e.g., enemies, NPCs) that can have their own unique speeds while still adhering to the common interface defined in the Character class. This demonstrates polymorphism, as we can treat all characters as instances of the Character class while allowing for specific behaviors (like movement speed) to be defined in each subclass.
    private void MoveFunction()
    {
        // Example of player movement using the Speed property
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * Speed * Time.deltaTime, Space.World);
    }
    

    protected override void Die()
    {
        // Implement player death behavior here (e.g., play animation, disable controls, etc.)
        Debug.Log("Player has died!");
        // For example, we could disable the player GameObject
        gameObject.SetActive(false);
    }

}
