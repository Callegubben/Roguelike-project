using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New level data", menuName = "Level Data/Level Data Manager")]

public class LevelDataManager : ScriptableObject
{
    public List<LevelData> allLevelData;

    public void DeathReset()
    {
        foreach (var item in allLevelData)
        {
            item.LoadDefaultState();
        }
    }
}
