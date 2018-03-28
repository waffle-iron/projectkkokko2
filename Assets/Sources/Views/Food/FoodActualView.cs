using UnityEngine;
using System.Collections;
using Entitas;
using System;
using UniRx;

public class FoodActualView : View
{
    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private Transform _leftBound;
    [SerializeField]
    private Transform _rightBound;

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        _sprite.enabled = false;
        var gameEty = ((GameEntity)entity);
        var food = gameEty.food;
        return this.contexts.meta.viewService.instance.GetAsset<Sprite>(food.id, (sprite) =>
        {
            _sprite.sprite = sprite;
            _sprite.enabled = true;
            var xPos = UnityEngine.Random.Range(_leftBound.position.x, _rightBound.position.y);
            var newPos = _sprite.transform.position;
            newPos.x = xPos;
            _sprite.transform.position = newPos;
        });
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEty = ((GameEntity)entity);

    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEty = ((GameEntity)entity);
    }

    protected override void Update ()
    {
        base.Update();

        var inputEty = contexts.input.CreateEntity();
        inputEty.AddTargetEntityID(this.ID);
        inputEty.AddPosition(_sprite.transform.position);
    }
}
