using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class JSONSaving : MonoBehaviour
{

    public PlayerStats playerStats;
    public Inventory inventory;
    public InventoryUI inventoryUI;
    public string Name;
    public float MaxHealth;
    public float CurrentHealth;
    private int Speed;

    [TextArea(4,20)] public string JsonData;
    private string filename = "Savedata.game";
    private string path;


    private void OnEnable()
    {
        LoadPlayerData();
    }

    private void OnDisable()
    {
       // SavePlayerData();
    }

    public void LoadPlayerData()
    {
        path = Application.persistentDataPath;
        using (FileStream stream = File.OpenRead($"{path}\\{filename}"))
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
            Name = loadData.Name;
            MaxHealth = loadData.MaxHealth;
            CurrentHealth = loadData.CurrentHealth;
            gameObject.transform.position = loadData.Position;
            Speed = loadData.Speed;
        }
    }
    public void SavePlayerData()
    {

        path = Application.persistentDataPath + $"\\{filename}";
        print(path);
        PlayerData playerData = new PlayerData
        {
            Name = Name,
            MaxHealth = MaxHealth,
            CurrentHealth = CurrentHealth,
            Position = transform.position,
            Speed = Speed
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
    public string Name;
    public float MaxHealth;
    public float CurrentHealth;
    public int Speed;
    public Vector3 Position;
}
