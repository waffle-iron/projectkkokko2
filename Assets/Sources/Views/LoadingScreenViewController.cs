using UnityEngine;
using System.Collections;
using Entitas;

public class LoadingScreenViewController : View, IGameLoadSceneListener, IGameLoadSceneRemovedListener
{
    public void OnLoadScene (GameEntity entity, string name)
    {
    }

    public void OnLoadSceneRemoved (GameEntity entity)
    {
    }

    protected override void RegisterListeners (IEntity entity, IContext context)
    {
        ((GameEntity)entity).AddGameLoadSceneListener(this);
        ((GameEntity)entity).AddGameLoadSceneRemovedListener(this);
    }
}
