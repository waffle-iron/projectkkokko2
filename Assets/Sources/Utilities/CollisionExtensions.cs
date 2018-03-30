using System;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionExtensions
{
    public static void CreateCollisionEntity (this Collider2D col, Contexts contexts, uint id, CollisionType type)
    {
        var other = col.GetComponentInChildren<View>();
        if (other != null)
        {
            var inputEty = contexts.input.CreateEntity();
            inputEty.AddTargetEntityID(id);
            inputEty.AddOnCollision(other.ID, type);
        }
    }

    public static void CreateCollisionEntity (this Collision2D col, Contexts contexts, uint id, CollisionType type)
    {
        var other = col.gameObject.GetComponentInChildren<View>();
        if (other != null)
        {
            var inputEty = contexts.input.CreateEntity();
            inputEty.AddTargetEntityID(id);
            inputEty.AddOnCollision(other.ID, type);
        }
    }
}

