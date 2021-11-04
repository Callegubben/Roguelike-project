using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerBase playerCharacterStats;

    public new string name;
    public float maxHealth;
    public float currentHealth;
    public float speed;

    private void OnEnable()
    {
        name = playerCharacterStats.name;
        maxHealth = playerCharacterStats.maxHealth;
        currentHealth = playerCharacterStats.currentHealth;
        speed = playerCharacterStats.speed;
    }
}
