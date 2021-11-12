using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : Stats
{

    [SerializeField] private SaveManager saveManager;
    [SerializeField] private Inventory inventory;
    [SerializeField] private LevelDataManager levelDataManager;


    public PlayerBase defaultPlayerCharacterStats;

    public Vector3 position;

    public string currentScene;
    public int lastCheckpoint;
    [HideInInspector]
    public bool iFrames;

    private void OnEnable()
    {
        if (creatureName == "")
        {
            LoadDefaultStats();
        }
        position = transform.position;
        if (!(SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "WinScreen"))
        {
            currentScene = SceneManager.GetActiveScene().name;
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
        creatureName = defaultPlayerCharacterStats.creatureName;
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

    public void PlayerWin()
    {
        currentScene = "Hub";
        lastCheckpoint = 0;
        inventory.ClearInventory();
        LoadDefaultStats();
        transform.position = Vector3.zero;
        saveManager.SavePlayerData();
        levelDataManager.DeathReset();
    }

    public void TookDamage()
    {
        StartCoroutine(IFrames());
    }

    IEnumerator IFrames()
    {
        iFrames = true;
        yield return new WaitForSecondsRealtime(1f);
        iFrames = false;
    }
}
