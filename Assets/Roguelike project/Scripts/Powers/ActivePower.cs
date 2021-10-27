using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New active power", menuName = "Powers/Active power")]

public class ActivePower : Power
{
    public PowerType powerType = PowerType.Active;

    public override void UsePower()
    {
        base.UsePower();
    }
}
