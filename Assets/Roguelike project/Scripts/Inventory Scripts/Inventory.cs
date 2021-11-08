using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public InventoryUI inventoryUI;
    public List<PassivePower> passivePowersInventory;
    public ActivePower currentActivePower;
    [HideInInspector] public bool addItemTriggered;
    private bool onCooldown;


    private void OnEnable()
    {
        foreach (var item in passivePowersInventory)
        {
            inventoryUI.DrawUIPassivePower();
        }
        if (currentActivePower != null)
        {
            inventoryUI.DrawUIActivePower();
        }
    }
    private void LateUpdate()
    {
        addItemTriggered = false;
    }

    public void AddPassiveItemToInventory(PassivePower powerToAdd)
    {
        passivePowersInventory.Add(powerToAdd);
        inventoryUI.DrawUIPassivePower();
    }
    public void AddActiveItemToInventory(ActivePower powerToAdd)
    {
        currentActivePower = powerToAdd;
        inventoryUI.DrawUIActivePower();
    }

    public void ClearInventory()
    {
        currentActivePower = null;
        player.GetComponent<PlayerStats>().LoadDefaultStats();
        passivePowersInventory.Clear();
        inventoryUI.ResetInventoryUI();
    }

    public void ActivateCurrentPower()
    {
        if (!onCooldown)
        {
            currentActivePower.UsePower();
            StartCoroutine(CooldownTimer());
        }
        else if (onCooldown)
        {
            print("Ability on cooldown");
        }
    }


    IEnumerator CooldownTimer()
    {
        onCooldown = true;
        yield return new WaitForSecondsRealtime(currentActivePower.cooldownTime);
        onCooldown = false;
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 80, 100, 30), "Clear Inventory"))
        {
            ClearInventory();
        }
    }
}
