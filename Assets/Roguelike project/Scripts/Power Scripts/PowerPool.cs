using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New power pool", menuName = "Powers/Power pool")]

public class PowerPool : ScriptableObject
{
    public List<Power> pool;
}
