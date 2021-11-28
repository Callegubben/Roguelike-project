using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{
    public Power power;
    Power tmpPower;
    public SpriteRenderer powerSprite;
    public Inventory playerInventory;
    private bool pickupCooldown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D && !pickupCooldown)
        {
            PickUpEvent();
            if (tmpPower != null)
            {
                StartCoroutine(PickupCooldown());
            }
        }
    }
    public void UpdatePowerIcon()
    {
        gameObject.SetActive(true);
        powerSprite.sprite = power.icon;
    }

    public void PickUpEvent()
    {
        switch (power.type)
        {
            case Power.PowerType.Active:
                tmpPower = playerInventory.currentActivePower;
                playerInventory.AddActiveItemToInventory((ActivePower)power);
                gameObject.SetActive(false);
                break;
            case Power.PowerType.Passive:
                FindObjectOfType<EffectManager>().PassivePowerEffect(power.powerID);
                playerInventory.AddPassiveItemToInventory((PassivePower)power);
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
        if (tmpPower == null)
        {
            gameObject.SendMessageUpwards("Took");
        }
        else
        {
            power = tmpPower;
            UpdatePowerIcon();
        }
    }

    IEnumerator PickupCooldown()
    {
        pickupCooldown = true;
        yield return new WaitForSecondsRealtime(1f);
        pickupCooldown = false;
    }

}
