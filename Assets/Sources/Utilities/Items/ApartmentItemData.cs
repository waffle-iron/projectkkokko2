using System;
using UnityEngine;

[System.Serializable]
public class ApartmentItemData
{
    public ApartmentItemType type;
    public string id;

    public static ApartmentItemData Empty
    {
        get {
            return new ApartmentItemData(ApartmentItemType.NONE, "");
        }
    }

    public ApartmentItemData (ApartmentItemType type, string id)
    {
        this.type = type;
        this.id = id;
    }
}

