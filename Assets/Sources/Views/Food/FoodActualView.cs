using UnityEngine;
using System.Collections;
using Entitas;
using System;
using UniRx;

public class FoodActualView : View, IGameTriggerListener
{
    [SerializeField]
    private SpriteRenderer _sprite;

    protected override void Update ()
    {
        base.Update();

        var inputEty = contexts.input.CreateEntity();
        inputEty.AddTargetEntityID(this.ID);
        inputEty.AddPosition(_sprite.transform.position);
    }

    protected override void OnTriggerEnter2D (Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        collision.CreateCollisionEntity(contexts, this.ID, CollisionType.ENTER);
    }

    protected override void OnTriggerExit2D (Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        collision.CreateCollisionEntity(contexts, this.ID, CollisionType.EXIT);
    }

    public void OnTrigger (GameEntity entity, DurationType duration, bool state)
    {
        if (state == true)
        {
            var inputEty = contexts.input.CreateEntity();
            inputEty.AddTargetEntityID(this.ID);
            inputEty.isConsumed = true;
            inputEty.AddDelayDestroy(1);
        }
    }

    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        _sprite.enabled = false;
        var gameEty = ((GameEntity)entity);
        var food = gameEty.food;
        return this.contexts.meta.viewService.instance.GetAsset<Sprite>(food.id, (sprite) =>
        {
            _sprite.sprite = sprite;
            _sprite.enabled = true;
            var spawnPos = ApartmentPositionsReference.Instance.LEFT_SPAWN_BOUNDS.RandomXPosition(ApartmentPositionsReference.Instance.RIGHT_SPAWN_BOUNDS);
            this.transform.position = spawnPos;
        });
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEty = ((GameEntity)entity);
        gameEty.AddGameTriggerListener(this);
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEty = ((GameEntity)entity);
        gameEty.RemoveGameTriggerListener(this);
    }

}
