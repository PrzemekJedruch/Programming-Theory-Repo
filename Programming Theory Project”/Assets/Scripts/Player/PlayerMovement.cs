using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : Player
{

    // The PlayerMovement class inherits from Player, which in turn inherits from Character.
    // This means that PlayerMovement has access to all the properties and methods defined in both Player and Character, including the overridden MaxHealth and Speed properties.
    private Rigidbody rb;
    // The movement vector will be calculated based on player input and used to move the player in the FixedUpdate method.
    private Vector3 movement;

    void Start()
    {
        // Get the Rigidbody component attached to the player GameObject. This is necessary for moving the player using physics.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ENKAPSULASION: The Moving method is responsible for calculating the movement vector based on player input. By calling this method in Update, we ensure that the movement vector is updated every frame based on the player's input.
        Moving();
    }

    void FixedUpdate()
    {
        // ENKAPSULASION: The MovingPosition method is responsible for moving the player based on the calculated movement vector and the player's speed. By calling this method in FixedUpdate, we ensure that the player's movement is consistent with the physics engine's update cycle.
        MovingPosition();
    }

    private void Moving()
    {
        // This method is not currently used, but it can be implemented to handle additional movement logic if needed.
        // For example, you could add sprinting, crouching, or other movement mechanics here.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        movement = transform.right * h + transform.forward * v;

    }   

    private void MovingPosition()
    {
        // This method is not currently used, but it can be implemented to handle movement based on the player's position if needed.
        // For example, you could implement a movement system that moves the player towards a target position or along a path.
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }


}