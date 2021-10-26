using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject player;
    private BoxCollider2D checkpointArea;
    private void OnEnable()
    {
        checkpointArea = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && collision is CircleCollider2D)
        {
            player.GetComponent<JSONSaving>().SavePlayerData();
        }
    }
}
