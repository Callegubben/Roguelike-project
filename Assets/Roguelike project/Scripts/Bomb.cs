using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [HideInInspector] public EffectManager effectManager;
    public Animator animator;
    private LayerMask destructibleLayers;

    public float fuseTimer = 2f;
    public float explosionRadius = 2f;
    public float damageValue = 10f;

    private void Awake()
    {
        destructibleLayers = LayerMask.GetMask("Player", "Enemy");
        effectManager = FindObjectOfType<EffectManager>();
    }
    private void OnEnable()
    {
        StartCoroutine(StartFuse());
    }


    public void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, destructibleLayers);
        foreach (var item in hits)
        {
            effectManager.DoDamage(item.gameObject.GetComponent<Stats>(), damageValue);
        }
        Destroy(gameObject);
    }

    public void DamageTargetsInRange()
    {
       // List<Stats> hits = damageArea.
    }

    IEnumerator StartFuse()
    {
        yield return new WaitForSecondsRealtime(fuseTimer);
        animator.SetTrigger("Explode");
    }
}
