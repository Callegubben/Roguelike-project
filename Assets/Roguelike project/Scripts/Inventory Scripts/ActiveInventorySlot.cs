using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveInventorySlot : MonoBehaviour
{
    public Image icon;
    ActivePower power;

    public void AddPower(ActivePower newPower)
    {
        if (power != null)
        {
            DropCurrentPower();
        }
        power = newPower;
        icon.sprite = power.icon;
    }

    private void DropCurrentPower()
    {
        print("Old active power replaced");
    }

    public void Clear()
    {
        power = null;
        icon.sprite = null;
    }

    IEnumerator OnCooldown(float cooldownTime)
    {
        yield return new WaitForSecondsRealtime(cooldownTime);
    }
}
