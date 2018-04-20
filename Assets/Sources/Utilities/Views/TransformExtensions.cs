using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class TransformExtensions
{
    /// <summary>
    /// will use the y and z pos of the first param transform
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="seed"></param>
    public static Vector3 RandomXPosition (this Transform left, Transform right, int seed = 0)
    {
        if (seed != 0) { Random.InitState(seed); }
        else { Random.InitState((int)System.DateTime.Now.Ticks); }
        var leftPos = left.position;
        var newX = Random.Range(left.position.x, right.position.x);
        return new Vector3(newX, leftPos.y, leftPos.z);
    }

    /// <summary>
    /// will use the y and z pos of the first param transform
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="seed"></param>
    public static Vector3 RandomYPosition (this Transform left, Transform right, int seed = 0)
    {
        if (seed != 0) { Random.InitState(seed); }
        var leftPos = left.position;
        var newY = Random.Range(left.position.y, right.position.y);
        return new Vector3(leftPos.x, newY, leftPos.z);
    }

    public static Vector2 RandomXYPosition (Vector2 xRange, Vector2 yRange, int seed = 0)
    {
        if (seed != 0) { Random.InitState(seed); }
        var newPos = Vector2.zero;

        newPos.x = Random.Range(xRange.x, xRange.y);
        newPos.y = Random.Range(yRange.y, yRange.y);

        return newPos;
    }

    public static Vector2[] ToArray (this Vector2 size)
    {
        var indexes = new Vector2[(int)size.x * (int)size.y];

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                indexes[x + y] = new Vector2(x, y);
            }
        }

        return indexes;
    }

    public static void ReplaceXPos (this Transform trans, float newX)
    {
        var newPos = trans.position;
        newPos.x = newX;
        trans.position = newPos;
    }

    public static void ReplaceYPos (this Transform trans, float newY)
    {
        var newPos = trans.position;
        newPos.y = newY;
        trans.position = newPos;
    }

    public static void ReplaceZPos (this Transform trans, float newZ)
    {
        var newPos = trans.position;
        newPos.z = newZ;
        trans.position = newPos;
    }

    public static void CreatePositionEntity (this Transform transform, Contexts contexts, uint myID)
    {
        var newEty = contexts.input.CreateEntity();
        newEty.AddTargetEntityID(myID);
        newEty.AddPosition(transform.position);
        newEty.AddDelayDestroy(1);
    }

    public static void CreateTargetPositionEntity (this Transform transform, Contexts contexts, uint myID)
    {
        var newEty = contexts.input.CreateEntity();
        newEty.AddTargetEntityID(myID);
        newEty.AddTargetPosition(transform.position);
        newEty.AddDelayDestroy(1);
    }

    public static IEnumerator Move (this Transform me, Vector3 destination, AnimationCurve easing, float duration)
    {
        float timer = 0.0f;
        while (timer <= duration)
        {
            me.position = Vector3.Lerp(me.position, destination, easing.Evaluate(timer / duration));
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public static IEnumerator Move (this Transform me, Transform destination, AnimationCurve easing, float duration)
    {
        return (Move(me, destination.position, easing, duration));
    }
}
