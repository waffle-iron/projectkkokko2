using System;
using System.Collections.Generic;
using Entitas;
using Spine;
using Spine.Unity;
using UnityEngine;

public class CharacterAccessoryView : View, IGamePreviewListener, IGameAccessoryListener
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

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGamePreviewListener(this);

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
    }

    public void OnPreview (GameEntity entity)
    {
        if (_isInitialized)
        {
            _charRef.Apply(_sprite, _type);

        }
    }

    public void OnAccessory (GameEntity entity, AccessoryID id, AccessoryType type)
    {
        _type = type;
        _sprite = Resources.Load<Sprite>(Enum.GetName(typeof(AccessoryID), id));
        _isInitialized = true;
    }
}

