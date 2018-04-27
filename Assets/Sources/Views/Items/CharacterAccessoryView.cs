using System;
using System.Collections.Generic;
using Entitas;
using Spine;
using Spine.Unity;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAccessoryView : View, IGamePreviewListener, IGamePreviewRemovedListener, IGameAccessoryListener, IGameEquippedListener
{
    [Tag, SerializeField]
    private string characterTarget;
    [SerializeField]
    private Image _nonCharacterView;

    private SpineCharacterAccessories _charRef;
    private Sprite _sprite;
    private AccessoryType _type;
    private bool _isInitialized = false;


    protected override IObservable<bool> Initialize (IEntity entity, IContext context)
    {
        _charRef = GameObject.FindGameObjectWithTag(characterTarget).GetComponent<SpineCharacterAccessories>();
        //_charRef.Hide();
        _nonCharacterView.enabled = false;
        return Observable.Return(true);
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddGamePreviewListener(this);
        gameEntity.AddGameEquippedListener(this);
        gameEntity.AddGamePreviewRemovedListener(this);
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
        gameEntity.RemoveGamePreviewRemovedListener(this);
    }

    public void OnPreview (GameEntity entity)
    {
        if (_isInitialized && entity.hasAccessory)
        {
            _charRef.Show();
            _nonCharacterView.enabled = false;
            _charRef.Apply(_sprite, _type);
        }
        else
        {
            _charRef.Hide();
            _nonCharacterView.enabled = true;

            var spriteName = "";
            if (entity.hasFood) { spriteName = entity.food.id; }
            else if (entity.hasApartmentItem) { spriteName = entity.apartmentItem.data.id; }

            if (spriteName != "")
            {
                this.contexts.meta.viewService.instance.GetAsset<Sprite>(spriteName)
                    .Subscribe(sprite =>
                    {
                        _nonCharacterView.sprite = sprite;
                        _nonCharacterView.enabled = true;
                    });
            }
        }
    }

    public void OnPreviewRemoved (GameEntity entity)
    {

    }

    public void OnEquipped (GameEntity entity)
    {
        if (_isInitialized)
        {
            _charRef.Show();
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

