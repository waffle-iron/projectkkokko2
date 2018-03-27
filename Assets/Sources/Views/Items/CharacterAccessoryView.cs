using System;
using System.Collections.Generic;
using Entitas;
using Spine;
using Spine.Unity;
using UniRx;
using UnityEngine;

public class CharacterAccessoryView : View, IGamePreviewListener, IGameAccessoryListener, IGameEquippedListener
{
    [Tag, SerializeField]
    private string characterTarget;

    private SpineCharacterAccessories _charRef;
    private Sprite _sprite;
    private AccessoryType _type;
    private bool _isInitialized = false;

    protected override void Awake ()
    {
        base.Awake();
        _charRef = GameObject.FindGameObjectWithTag(characterTarget).GetComponent<SpineCharacterAccessories>();
    }

    protected override void OnEnable ()
    {
        base.OnEnable();
    }

    protected override IObservable<bool> Initialize ()
    {
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGamePreviewListener(this);
        gameEntity.AddGameEquippedListener(this);
        if (gameEntity.hasAccessory)
        {
            OnAccessory(gameEntity, gameEntity.accessory.id, gameEntity.accessory.type);
            if (gameEntity.isEquipped)
            {
                OnPreview(gameEntity);
            }
        }
    }

    protected override void UnregisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.RemoveGamePreviewListener(this);
        gameEntity.RemoveGameEquippedListener(this);
    }

    public void OnPreview (GameEntity entity)
    {
        if (_isInitialized)
        {
            _charRef.Apply(_sprite, _type);

        }
    }

    public void OnEquipped (GameEntity entity)
    {
        if (_isInitialized)
        {
            _charRef.Apply(_sprite, _type);
        }
    }

    public void OnAccessory (GameEntity entity, string id, AccessoryType type)
    {
        contexts.meta.viewService.instance.GetAsset<Sprite>(id).Subscribe(sprite =>
        {
            _type = type;
            _sprite = sprite;
            _isInitialized = true;
        });
    }
}

