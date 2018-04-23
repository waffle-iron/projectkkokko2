using System;
using UnityEngine;

[System.Serializable]
public struct ApartmentItemData
{
    [SerializeField]
    private ApartmentItemType _type;
    [SerializeField]
    private string _id;

    public ApartmentItemType type { get { return _type; } private set { _type = value; } }
    public string id { get { return _id; } private set { _id = value; } }

    public static ApartmentItemData Empty
    {
        get {
            return new ApartmentItemData(ApartmentItemType.NONE, "");
        }
    }

    public ApartmentItemData (ApartmentItemType type, string id)
    {
        this._type = type;
        this._id = id;
    }
}

