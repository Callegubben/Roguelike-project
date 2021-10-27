using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject player;
    public void ChangeMaxHealth(float value)
    {
        player.GetComponent<PlayerStats>().maxHealth += value;
    }
}
