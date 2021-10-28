using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsePowers : MonoBehaviour
{
    public Power Power;
    public UnityEvent PickUpEvent;
    void Start()
    {
        if (PickUpEvent == null)
            PickUpEvent = new UnityEvent();
        gameObject.GetComponent<SpriteRenderer>().sprite = Power.icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {
            PickUpEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
