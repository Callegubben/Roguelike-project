using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class JSONSaving : MonoBehaviour
{
    PlayerData playerData;
    public string Name;
    public float Health;
    private int Strength;

    [TextArea] public string JsonData;
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
            Health = loadData.Health;
            gameObject.transform.position = loadData.Position;
            Strength = loadData.Strength;
        }
    }
    public void SavePlayerData()
    {
        path = Application.persistentDataPath;
        print(path);
        PlayerData _playerData = new PlayerData
        {
            Name = Name,
            Health = Health,
            Position = transform.position,
            Strength = Strength
        };
        JsonData = JsonUtility.ToJson(_playerData, true);
        using (FileStream stream = File.OpenWrite($"{path}\\{filename}"))
        {
            byte[] buffer = JsonData.Select(@char => (byte)@char).ToArray();
            stream.Write(buffer, 0, JsonData.Length);
        }
    }
}

public class PlayerData
{
    [Header("Player Data")]
    public string Name;
    public float Health;
    public Vector3 Position;

    [SerializeField] private int _strength;

    public int Strength { 
        get => _strength; 
        set => _strength = value; 
    }
}
