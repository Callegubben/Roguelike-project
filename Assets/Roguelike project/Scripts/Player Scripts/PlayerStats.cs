using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{

    [SerializeField] private SaveManager saveManager;
    [SerializeField] private Inventory inventory;
    [SerializeField] private LevelDataManager levelDataManager;


    public PlayerBase defaultPlayerCharacterStats;

    public new string name;
    public float maxHealth;
    public float currentHealth;
    public float speed;
    public Vector3 position;

    public string currentScene;
    public int lastCheckpoint;

    private void OnEnable()
    {
        if (name == "")
        {
            LoadDefaultStats();
        }
        position = transform.position;
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
        levelDataManager.DeathReset();
        SceneManager.LoadScene("Hub");

    }
}
