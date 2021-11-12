using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class SaveManager : MonoBehaviour
{
    public LevelData levelData;
    public PlayerStats playerStats;
    public Inventory inventory;
    public InventoryUI inventoryUI;
    public List<Checkpoint> checkpoints;
    public List<Altar> altars;


    [TextArea(4,20)] public string JsonData;
    private string filename = "Savedata.game";
    private string path;

    public GameObject defaultSpawn;

    private void OnEnable()
    {
        path = Application.persistentDataPath + $"\\{filename}";
        if (File.Exists(path))
        {
            LoadPlayerData();
        }
        if (levelData.firstLoad)
        {
            playerStats.gameObject.transform.position = defaultSpawn.transform.position;
            foreach (var item in altars)
            {
                item.SpawnItemFromPool();
            }
            foreach (var item in altars)
            {
                levelData.altarInfoList.Add(new AltarInfo(item.taken, item.powerSlot.power));
            }
            levelData.firstLoad = false;
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
            playerStats.creatureName = loadData.playerName;
            playerStats.maxHealth = loadData.maxHealth;
            playerStats.currentHealth = loadData.currentHealth;
            playerStats.speed = loadData.speed;
            playerStats.currentScene = loadData.currentScene;
            playerStats.lastCheckpoint = loadData.lastCheckpoint;
            inventory.currentActivePower = loadData.playerCurrentActivePower;
            inventory.passivePowersInventory = loadData.playerPassivePowersInventory;
            playerStats.transform.position = loadData.Position;
            int x = 0;
            foreach (var item in levelData.altarInfoList)
            {
                altars[x].taken = item.taken;
                altars[x].powerSlot.power = item.altarPower;
                if (!altars[x].taken)
                {
                    altars[x].powerSlot.UpdatePowerIcon();
                }
                x++;
            }
        }
    }
    public void SavePlayerData()
    {
        levelData.firstLoad = false;
        int i = 0;
        foreach (var item in altars)
        {
            levelData.altarInfoList[i].taken = item.taken;
            levelData.altarInfoList[i].altarPower = item.powerSlot.power;
            i++;
        }

        print(path);
        PlayerData playerData = new PlayerData
        {
            playerCharacter = playerStats.defaultPlayerCharacterStats,
            playerName = playerStats.creatureName,
            maxHealth = playerStats.maxHealth,
            currentHealth = playerStats.currentHealth,
            speed = playerStats.speed,
            playerCurrentActivePower = inventory.currentActivePower,
            playerPassivePowersInventory = inventory.passivePowersInventory,
            Position = playerStats.transform.position,
            currentScene = playerStats.currentScene,
            lastCheckpoint = playerStats.lastCheckpoint
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
    public string playerName;
    public float maxHealth;
    public float currentHealth;
    public float speed;
    public ActivePower playerCurrentActivePower;
    public List<PassivePower> playerPassivePowersInventory;
    public Vector3 Position;
    public string currentScene;
    public int lastCheckpoint;
}
