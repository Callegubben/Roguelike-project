using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerBase playerStats;

    public new string name;
    public float maxHealth;
    public float currentHealth;
    public float speed;

    private void OnEnable()
    {
        name = playerStats.name;
        maxHealth = playerStats.maxHealth;
        currentHealth = playerStats.currentHealth;
        speed = playerStats.speed;
    }
}
