using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private Object bombPrefab;
    public GameObject player;
    public Inventory inventory;
    private PlayerStats playerStats;

    private void OnEnable()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }
    public void ChangePlayerMaxHealth(float value)
    {
        playerStats.maxHealth += value;
        playerStats.currentHealth += value;
    }

    public void ChangePlayerSpeed(float value)
    {
        playerStats.speed += value;
    }

    public void DoDamage(Stats target, float value)
    {
        if (target is PlayerStats)
        {
            if (playerStats.iFrames)
            {
                return;
            }
            target.currentHealth -= value;
            target.SendMessage("TookDamage");
        }
        else
        {
            target.currentHealth -= value;
        }
    }

    public void ActivePowerEffect(int powerID)
    {
        switch (powerID)
        {
            case 1:
                GameObject newBomb = (GameObject)Instantiate(bombPrefab, player.transform.position, Quaternion.identity);
                newBomb.GetComponent<SpriteRenderer>().sprite = inventory.currentActivePower.icon;
                break;
                
            default:
                break;
        }
    }

    public void PassivePowerEffect(int powerID)
    {
        switch (powerID)
        {
            case 1:
                ChangePlayerMaxHealth(25f);
                break;

            case 2:
                ChangePlayerSpeed(5f);
                break;

            default:
                break;
        }
    }
}
