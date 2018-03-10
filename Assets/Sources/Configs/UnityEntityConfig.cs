using UnityEngine;
using System.Collections;
using Entitas;
using Entitas;

public abstract class UnityEntityConfig : ScriptableObject, IEntityConfig
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private string _viewName;

    public string Name
    {
        get {
            return _name;
        }
    }

    public IEntity Create ()
    {
        var entity = CustomCreate();
        if (_viewName.Equals("") == false)
        {
            ((GameEntity)entity).AddView(_viewName);
        }
        return entity;
    }

    protected abstract IEntity CustomCreate();
}
