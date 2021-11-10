using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{

    [SerializeField] private SaveManager saveManager;
    [SerializeField] private Inventory inventory;

    public PlayerBase defaultPlayerCharacterStats;

    public new string name;
    public float maxHealth;
    public float currentHealth;
    public float speed;

    public string currentScene;
    public Vector3 lastCheckpoint;

    private void OnEnable()
    {
        if (name == "")
        {
            LoadDefaultStats();
        }
    }

    private void LateUpdate()
    {
        if (currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void LoadDefaultStats()
    {
        name = defaultPlayerCharacterStats.name;
        maxHealth = defaultPlayerCharacterStats.maxHealth;
        currentHealth = defaultPlayerCharacterStats.currentHealth;
        speed = defaultPlayerCharacterStats.speed;
    }

    public void PlayerDeath()
    {
        inventory.ClearInventory();
        LoadDefaultStats();
        transform.position = Vector3.zero;
        saveManager.SavePlayerData();
        SceneManager.LoadScene("Hub");
    }
}
