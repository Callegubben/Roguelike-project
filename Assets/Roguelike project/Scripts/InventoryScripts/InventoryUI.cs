using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    UnityEvent pickupEvent;
    public Inventory inventory;

    public Transform itemSlotParent;
    public PassiveInventorySlot[] inventorySlots;

    public ActiveInventorySlot activeInventorySlot;

    public Object InventorySlotPrefab;
    private float columnCount = 0, rowCount = 0;

    private void Start()
    {
        if (pickupEvent == null)
            pickupEvent = new UnityEvent();
        pickupEvent.AddListener(DrawUIPassivePower);
    }

    private void Update()
    {
        
    }

    public void DrawUIPassivePower()
    {
        float posX = 5 + (30 * columnCount);
        float posY = -5 - (30 * rowCount);
        Vector2 newSlotPosition = new Vector2(posX,posY);
        GameObject newInventorySlot = (GameObject)Instantiate(InventorySlotPrefab, itemSlotParent, false);
        RectTransform newSlotTransform = newInventorySlot.GetComponent<RectTransform>();
        newSlotTransform.anchoredPosition = newSlotPosition;
        newInventorySlot.GetComponent<PassiveInventorySlot>().AddPower(inventory.passivePowersInventory[inventory.passivePowersInventory.Count-1]);
        columnCount++;
        if (columnCount > 3)
        {
            columnCount = 0;
            rowCount++;
        }
    }

    public void DrawUIActivePower()
    {
        activeInventorySlot.AddPower(inventory.currentActivePower);
    }
}
