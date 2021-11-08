using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private Object bombPrefab;
    public GameObject player;
    public Inventory inventory;
    public void ChangePlayerMaxHealth(float value)
    {
        player.GetComponent<PlayerStats>().maxHealth += value;
        player.GetComponent<PlayerStats>().currentHealth += value;
    }

    public void DoDamage(float value)
    {
        player.GetComponent<PlayerStats>().currentHealth -= value;
    }

    public void ActivePowerEffect(int powerID)
    {
        switch (powerID)
        {
            case 2:
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

            default:
                break;
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 45, 60, 30), "Damage"))
        {
            DoDamage(10);
        }
    }
}
