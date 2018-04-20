using System;


[System.Serializable]
public struct ApartmentItemData
{
    public ApartmentItemType type { get; private set; }
    public String id { get; private set; }

    public static ApartmentItemData Empty
    {
        get {
            return new ApartmentItemData(ApartmentItemType.NONE, "");
        }
    }

    public ApartmentItemData (ApartmentItemType type, String id)
    {
        this.type = type;
        this.id = id;
    }
}

