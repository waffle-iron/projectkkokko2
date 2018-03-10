using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;

public class SaveView : View, ISavingListener, ISavingRemovedListener
{
    private int saveCount = 0;
    [SerializeField]
    private Image image;

    public void OnSaving (GameEntity entity)
    {
        saveCount++;
    }

    public void OnSavingRemoved (GameEntity entity)
    {
        saveCount--;
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddSavingListener(this);
        gameEntity.AddSavingRemovedListener(this);
    }

    protected override void Update ()
    {
        base.Update();
        if (saveCount > 0 && image.enabled == false)
        {
            image.gameObject.SetActive(true);
        }
        else if (saveCount == 0 && image.enabled)
        {
            image.gameObject.SetActive(false);
        }
    }
}
