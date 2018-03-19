using UnityEngine;
using System.Collections;
using Entitas;
using CodeStage.AntiCheat.ObscuredTypes;

public abstract class UnityEntityConfig : ScriptableObject, IEntityConfig
{
    [Header("ENTITY AND VIEW IDS")]
    [SerializeField]
    private EntityCfgID _name;

    [Header("View Settings")]
    [SerializeField]
    private string _viewName;
    [SerializeField]
    private bool _isDestroyOnSceneChange = true;

    [Header("Load Data Settings")]
    [SerializeField]
    private ObscuredString saveID = "";
    [SerializeField]
    private bool _loadOnStart = false;

    private string _srcPath = "";

    public EntityCfgID Name
    {
        get {
            return _name;
        }
    }

    public string srcPath
    {
        get {
            return _srcPath;
        }

        set {
            _srcPath = value;
        }
    }

    public IEntity Create (Contexts contexts)
    {
        var entity = CustomCreate(contexts);
        if (_viewName.Equals("") == false)
        {
            ((GameEntity)entity).AddView(_viewName, _isDestroyOnSceneChange);
        }

        if (saveID.Equals("") == false)
        {
            ((GameEntity)entity).AddSaveID(saveID);
        }

        if (_loadOnStart && saveID.Equals("") == false)
        {
            var inputEntity = contexts.input.CreateEntity();
            inputEntity.AddLoad(saveID, false);
            inputEntity.AddTargetEntityID(((IIDEntity)entity).iD.value);
        }

        return entity;
    }

    protected abstract IEntity CustomCreate (Contexts contexts);
}
