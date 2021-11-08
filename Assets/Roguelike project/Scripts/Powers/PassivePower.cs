using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New passive power", menuName = "Powers/Passive power")]
public class PassivePower : Power
{
    public override void UsePower()
    {

    }

    PassivePower()
    {
        type = PowerType.Passive;
    }
}
