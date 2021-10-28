using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    PassivePower power;

    public void AddPower(PassivePower newPower)
    {
        power = newPower;
        icon.sprite = power.icon;
        Color tmpColor = icon.color;
        tmpColor.a = 0.5f;
        icon.color = tmpColor;
    }
}
