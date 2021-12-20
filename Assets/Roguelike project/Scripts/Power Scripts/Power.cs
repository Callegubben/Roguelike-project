using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Power : ScriptableObject
{
    public string powerName;
    public int powerID;
    public int powerEffect;
    public string powerDescription;
    public Sprite icon;
    [HideInInspector]
    public PowerType type;

    public virtual void UsePower()
    {

    }
}
public enum PowerType
{
    Active,
    Passive
}
