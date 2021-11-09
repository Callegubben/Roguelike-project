using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SaveManager playerSaving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CircleCollider2D)
        {
            playerSaving.SavePlayerData();
        }
    }
}
