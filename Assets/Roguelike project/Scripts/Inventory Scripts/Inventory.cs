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

    private void Start()
    {
        if (!(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "WinScreen"))
        {
            RedrawInventoryUI();
        }
    }

    private void RedrawInventoryUI()
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
        passivePowersInventory.Clear();
        if (!(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu" || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "WinScreen"))
        {
            inventoryUI.ResetInventoryUI();
        }
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
}
