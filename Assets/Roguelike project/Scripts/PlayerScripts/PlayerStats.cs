using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerBase defaultPlayerCharacterStats;

    public new string name;
    public float maxHealth;
    public float currentHealth;
    public float speed;

    private void OnEnable()
    {
        name = defaultPlayerCharacterStats.name;
    }

    public void LoadDefaultStats()
    {
        name = defaultPlayerCharacterStats.name;
        maxHealth = defaultPlayerCharacterStats.maxHealth;
        currentHealth = defaultPlayerCharacterStats.currentHealth;
        speed = defaultPlayerCharacterStats.speed;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 115, 150, 30), "Load default stats"))
        {
            LoadDefaultStats();
        }
    }
}
