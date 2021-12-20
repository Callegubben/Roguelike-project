using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New active power", menuName = "Powers/Active power")]

public class ActivePower : Power
{
    public float cooldownTime;

    public override void UsePower()
    {
        FindObjectOfType<EffectManager>().ActivePowerEffect(this.powerEffect);
    }

    ActivePower()
    {
        type = PowerType.Active;
    }
}
