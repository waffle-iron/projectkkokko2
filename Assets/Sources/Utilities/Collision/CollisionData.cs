using System;

public struct CollisionData
{
    public uint ID { get; private set; }
    public CollisionType Type { get; private set; }

    public CollisionData (uint id, CollisionType type)
    {
        this.ID = id;
        this.Type = type;
    }
}
