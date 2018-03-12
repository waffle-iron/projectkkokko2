using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DurationType
{
    public float length;
    public UnitTime unit;

    public DurationType(float length, UnitTime unit)
    {
        this.length = length;
        this.unit = unit;
    }
}
