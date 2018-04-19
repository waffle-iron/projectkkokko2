using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CollisionExtensions
{
    public static void CreateCollisionEntity (this Collider2D[] col, Contexts contexts, uint myID, CollisionType type)
    {

        var other = col.Select(cl => cl.GetComponentInChildren<View>())
            .Where(cl => cl != null)
            .Select(cl => new CollisionData(cl.ID, type)).ToArray();

        if (other != null || other.Length > 0)
        {
            var inputEty = contexts.input.CreateEntity();
            inputEty.AddTargetEntityID(myID);
            inputEty.AddOnCollision(other);
        }
    }

    public static void CreateCollisionEntity (this CollisionData[] cols, Contexts contexts, uint myID)
    {
        if (cols != null || cols.Length > 0)
        {
            var inputEty = contexts.input.CreateEntity();
            inputEty.AddTargetEntityID(myID);
            inputEty.AddOnCollision(cols);
        }
    }

    public static void CreateCollisionEntity (this Collider2D col, Contexts contexts, uint myID, CollisionType type)
    {
        var other = col.GetComponentInChildren<View>();
        if (other != null)
        {
            var inputEty = contexts.input.CreateEntity();
            inputEty.AddTargetEntityID(myID);
            inputEty.AddOnCollision(new CollisionData[] { new CollisionData(other.ID, type) });
        }
    }

    public static void CreateCollisionEntity (this Collision2D col, Contexts contexts, uint myID, CollisionType type)
    {
        var other = col.gameObject.GetComponentInChildren<View>();
        if (other != null)
        {
            var inputEty = contexts.input.CreateEntity();
            inputEty.AddTargetEntityID(myID);
            inputEty.AddOnCollision(new CollisionData[] { new CollisionData(other.ID, type) });
        }
    }
}

