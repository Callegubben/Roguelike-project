using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumStats : Stats
{
    public OpossumStats()
    {
        creatureName = "Opossum";
        maxHealth = 10;
        currentHealth = maxHealth;
        speed = 10;
    }

    private void LateUpdate()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
