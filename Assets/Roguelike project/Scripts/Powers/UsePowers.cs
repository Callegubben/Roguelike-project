using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsePowers : MonoBehaviour
{
    public PassivePower passivePower;
    public UnityEvent PickUpEvent;
    void Start()
    {
        if (PickUpEvent == null)
            PickUpEvent = new UnityEvent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {
            PickUpEvent.Invoke();
        }
    }
}
