using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;

public class LoadView : View, ILoadingListener, ILoadingRemovedListener
{
    private int loadCount = 0;
    [SerializeField]
    private Image image;

    public void OnLoading (GameEntity entity)
    {
        this.loadCount++;
    }

    public void OnLoadingRemoved (GameEntity entity)
    {
        this.loadCount--;
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        var gameEntity = (GameEntity)entity;
        gameEntity.AddLoadingListener(this);
        gameEntity.AddLoadingRemovedListener(this);
    }

    protected override void Update ()
    {
        base.Update();
        if (loadCount > 0 && image.enabled == false)
        {
            image.gameObject.SetActive(true);
        }
        else if (loadCount == 0 && image.enabled)
        {
            image.gameObject.SetActive(false);
        }
    }
}
