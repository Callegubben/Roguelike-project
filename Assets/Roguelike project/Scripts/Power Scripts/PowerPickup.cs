using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{
    public Power power;
    public SpriteRenderer powerSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {
            PickUpEvent();
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
                FindObjectOfType<Inventory>().AddActiveItemToInventory((ActivePower)power);
                gameObject.SetActive(false);
                break;
            case Power.PowerType.Passive:
                FindObjectOfType<EffectManager>().PassivePowerEffect(power.powerID);
                FindObjectOfType<Inventory>().AddPassiveItemToInventory((PassivePower)power);
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
        gameObject.SendMessageUpwards("Took");
    }
}
