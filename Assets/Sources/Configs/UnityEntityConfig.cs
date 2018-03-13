using UnityEngine;
using System.Collections;
using Entitas;

public abstract class UnityEntityConfig : ScriptableObject, IEntityConfig
{
    [Header("ENTITY AND VIEW IDS")]
    [SerializeField]
    private EntityCfgID _name;

    [SerializeField]
    private string _viewName;

    public EntityCfgID Name
    {
        get {
            return _name;
        }
    }

    public IEntity Create (Contexts contexts)
    {
        var entity = CustomCreate(contexts);
        if (_viewName.Equals("") == false)
        {
            ((GameEntity)entity).AddView(_viewName);
        }
        return entity;
    }

    protected abstract IEntity CustomCreate(Contexts contexts);
}
