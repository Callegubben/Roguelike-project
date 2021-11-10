using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class SaveManager : MonoBehaviour
{

    public PlayerStats playerStats;
    public Inventory inventory;
    public InventoryUI inventoryUI;


    [TextArea(4,20)] public string JsonData;
    private string filename = "Savedata.game";
    private string path;

    private void OnEnable()
    {
        path = Application.persistentDataPath + $"\\{filename}";
        if (File.Exists(path))
        {
            LoadPlayerData();
        }
    }

    public void LoadPlayerData()
    {
        using (FileStream stream = File.OpenRead(path))
        {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            char[] data = new char[buffer.Length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (char)buffer[i];
            }
            JsonData = new string(data);
            PlayerData loadData = JsonUtility.FromJson<PlayerData>(JsonData);
            playerStats.defaultPlayerCharacterStats = loadData.playerCharacter;
            playerStats.maxHealth = loadData.maxHealth;
            playerStats.currentHealth = loadData.currentHealth;
            playerStats.speed = loadData.speed;
            playerStats.currentScene = loadData.currentScene;
            inventory.currentActivePower = loadData.playerCurrentActivePower;
            inventory.passivePowersInventory = loadData.playerPassivePowersInventory;
            try
            {
                playerStats.transform.position = loadData.lastCheckpoint.transform.position;
            }
            catch (MissingReferenceException)
            {
                playerStats.transform.position = GameObject.Find("DefaultSpawn").transform.position;
            }
            catch (NullReferenceException)
            {
                playerStats.transform.position = GameObject.Find("DefaultSpawn").transform.position;
            }
        }
    }
    public void SavePlayerData(Checkpoint checkpoint)
    {
        print(path);
        PlayerData playerData = new PlayerData
        {
            playerCharacter = playerStats.defaultPlayerCharacterStats,
            maxHealth = playerStats.maxHealth,
            currentHealth = playerStats.currentHealth,
            speed = playerStats.speed,
            playerCurrentActivePower = inventory.currentActivePower,
            playerPassivePowersInventory = inventory.passivePowersInventory,
            Position = playerStats.transform.position,
            currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name,
            lastCheckpoint = checkpoint
        };
        JsonData = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(path, "");
        using (FileStream stream = File.OpenWrite(path))
        {
            byte[] buffer = JsonData.Select(@char => (byte)@char).ToArray();
            stream.Write(buffer, 0, JsonData.Length);
        }
    }
}

[Serializable]
public class PlayerData 
{
    public PlayerBase playerCharacter;
    public float maxHealth;
    public float currentHealth;
    public float speed;
    public ActivePower playerCurrentActivePower;
    public List<PassivePower> playerPassivePowersInventory;
    public Vector3 Position;
    public string currentScene;
    public Checkpoint lastCheckpoint;
}
