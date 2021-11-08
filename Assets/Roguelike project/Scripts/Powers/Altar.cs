using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private PowerPool altarPool;
    public PowerPickup powerSlot;

    private void OnEnable()
    {
        SpawnItemFromPool();
    }
    public void SpawnItemFromPool()
    {
        /*int randomNumber = Random.Range(0, altarPool.pool.Count);
        Power tmpPower = altarPool.pool[randomNumber];*/
        powerSlot.power = altarPool.pool[Random.Range(0, altarPool.pool.Count)];
        powerSlot.UpdatePowerIcon();

    }
}
