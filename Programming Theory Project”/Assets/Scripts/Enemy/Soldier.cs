using UnityEngine;

public class Soldier : Enemy
{
    [Header("Soldier Stats")]

    //--------- Health and Speed Properties with Encapsulation and Polymorphism ---------//
    // Additional properties specific to Soldier can be added here
    [SerializeField] private float soldierHealth = 150f; // Override the base max health for soldiers
    protected override float MaxHealth => soldierHealth; // Override the max health for soldiers

    [SerializeField] private float soldierSpeed = 7f; // Override the base speed for soldiers
    protected override float Speed => soldierSpeed; // Override the speed for soldiers



}
