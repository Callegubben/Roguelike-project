using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour
{
    public EffectManager effectManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is CircleCollider2D)
        {
            effectManager.DoDamage(collision.gameObject.GetComponent<Stats>() ,500);
        }
    }
}
