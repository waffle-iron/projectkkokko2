using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;
using UniRx;

public class GridView : View
{
    //insert serialized fields here
    [SerializeField]
    private bool isHorizontal;
    [SerializeField]
    private bool isVertical;
    [SerializeField]
    private GridSquare _gridSquarePrefab;

    private HashSet<GridSquare> squares = new HashSet<GridSquare>();
    private Vector2[] indexes;

    private string gridID;
    private HashSet<GridSquare> collisionData = new HashSet<GridSquare>();
    private IDisposable inputObservable;

    private GameObject lastSquare;

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        indexes = ((GameEntity)entity).gridApartmentData.values.Keys.ToArray();
        gridID = ((GameEntity)entity).grid.id;

        for (int ctr = 0; ctr < indexes.Length; ctr++)
        {
            var square = InstantiateSquare();
            squares.Add(square);
            square.index = indexes[ctr];
            square.OnTrigger += Square_OnTrigger;
        }

        inputObservable = Observable.EveryEndOfFrame().Subscribe(_ =>
        {
            if (collisionData.Count > 0)
            {
                var inputety = this.contexts.input.CreateEntity();
                inputety.AddGridCollision(this.gridID, collisionData);
                collisionData.Clear();
            }
        });

        return Observable.Return(true);
    }

    protected override void Cleanup ()
    {
        base.Cleanup();

        foreach (var square in squares)
        {
            square.OnTrigger -= Square_OnTrigger;
            Destroy(square);
        }

        inputObservable.Dispose();
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameety = (GameEntity)entity;
    }

    private void Square_OnTrigger (GridSquare obj)
    {
        this.collisionData.Add(obj);
    }

    private GridSquare InstantiateSquare ()
    {
        var square = GameObject.Instantiate(_gridSquarePrefab.gameObject);
        square.transform.SetParent(this.transform);
        square.SetActive(true);

        Vector3 newPos = square.transform.position;

        if (lastSquare != null)
        {
            newPos = lastSquare.transform.position;
        }
        else
        {
            lastSquare = square;
        }

        if (isHorizontal)
        {
            newPos.x += lastSquare.GetComponent<BoxCollider2D>().size.x;
        }
        if (isVertical)
        {
            newPos.y += lastSquare.GetComponent<BoxCollider2D>().size.y;
        }
        square.transform.position = newPos;
        lastSquare = square;

        return square.GetComponent<GridSquare>();
    }
}

