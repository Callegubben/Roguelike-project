using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


[CreateAssetMenu(fileName = "New level data", menuName = "Level Data/Level Data")]
public class LevelData : ScriptableObject
{
    public bool firstLoad = true;
    public List<AltarInfo> altarInfoList;

    public void LoadDefaultState()
    {
        firstLoad = true;
        altarInfoList.Clear();
    }
}

[Serializable]
public class AltarInfo
{
    public bool taken;
    public Power altarPower;

    public AltarInfo(bool taken, Power altarPower)
    {
        this.taken = taken;
        this.altarPower = altarPower;
    }
}
