using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New level data", menuName = "Level Data/Level Data")]
public class LevelData : ScriptableObject
{
    public bool firstLoad = true;
    public List<bool> altars;

    public void LoadDefaultState()
    {
        firstLoad = true;
        altars.Clear();
        /*for (int i = 0; i < altars.Count; i++)
        {
            altars[i] = false;
        }*/
    }
}
