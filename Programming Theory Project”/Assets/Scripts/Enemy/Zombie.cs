using UnityEngine;

public class Zombie : Enemy
{
    [Header("Zombie Stats")]

    //--------- Health and Speed Properties with Encapsulation and Polymorphism ---------//
    // Additional properties specific to Zombie can be added here
    [SerializeField] private float zombieHealth = 80f; // Override the base max health for zombies
    protected override float MaxHealth => zombieHealth; // Override the max health for zombies

    [SerializeField] private float zombieSpeed = 3f; // Override the base speed for zombies
    protected override float Speed => zombieSpeed; // Override the speed for zombies

    

}
