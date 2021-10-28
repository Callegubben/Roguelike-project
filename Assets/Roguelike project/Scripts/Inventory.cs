using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public List<PassivePower> passivePowersInventory;
    public ActivePower currentActivePower;
    [HideInInspector] public bool addItemTriggered;

    private void LateUpdate()
    {
        addItemTriggered = false;
    }

    public void AddItemToInventory(PassivePower powerToAdd)
    {
        passivePowersInventory.Add(powerToAdd);
        addItemTriggered = true;
    }
}
