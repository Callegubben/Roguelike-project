using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject player;
    public void ChangePlayerMaxHealth(float value)
    {
        player.GetComponent<PlayerStats>().maxHealth += value;
        player.GetComponent<PlayerStats>().currentHealth += value;
    }

    public void DoDamage(float value)
    {
        player.GetComponent<PlayerStats>().currentHealth -= value;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 45, 60, 30), "Damage"))
        {
            DoDamage(10);
        }
    }
}
