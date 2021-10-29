using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Power : ScriptableObject
{
    public string powerName;
    public int powerID;
    public string powerDescription;
    public Sprite icon;

    public virtual void UsePower()
    {
        print("Not Possible!")
    }

    public enum PowerType
    {
        Active,
        Passive
    }
}
