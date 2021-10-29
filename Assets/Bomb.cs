using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fuseTimer = 2f;
    public Animator animator;

    private void OnEnable()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(StartFuse());
    }


    public void Explode()
    {
        Destroy(gameObject);
    }
    IEnumerator StartFuse()
    {
        yield return new WaitForSecondsRealtime(fuseTimer);
        animator.SetTrigger("Explode");
    }
}
