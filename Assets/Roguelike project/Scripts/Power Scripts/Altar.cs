using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private PowerPool altarPool;
    [SerializeField] private LevelData levelData;
    public PowerPickup powerSlot;
    public int altarID;
    [HideInInspector]
    public bool taken = false;

    private void OnEnable()
    {
        if (levelData.firstLoad)
        {
            SpawnItemFromPool();
        }
    }
    public void SpawnItemFromPool()
    {
        powerSlot.power = altarPool.pool[Random.Range(0, altarPool.pool.Count)];
        powerSlot.UpdatePowerIcon();
        powerSlot.gameObject.SetActive(true);
    }

    public void Took()
    {
        taken = true;
    }
}
