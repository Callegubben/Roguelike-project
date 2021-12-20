using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New power database", menuName = "Powers/Power database")]
public class PowerDatabase : ScriptableObject
{
    public List<DatabaseObject> allPowers;

    public Power FindInDatabase(int id)
    {
        Power tmpPower = allPowers[id-1].power;
        return tmpPower;
    }

}

[Serializable]
public class DatabaseObject
{
    public int id;
    public Power power;

    public DatabaseObject(Power power)
    {
        this.power = power;
        this.id = power.powerID;
    }
}