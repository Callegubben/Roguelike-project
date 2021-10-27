using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New character", menuName = "Character")]

public class PlayerBase : ScriptableObject
{
    public new string name;
    public float maxHealth;
    public float currentHealth;
    public float speed;
}
