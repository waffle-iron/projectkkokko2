using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;
using System.Linq;

public class GenerateIDSystem : IInitializeSystem, ITearDownSystem
{
    Contexts _contexts;

    public GenerateIDSystem (Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize ()
    {
        _contexts.game.SetCurrentID(1);

        //foreach (var context in _contexts.allContexts)
        //{
        if (_contexts.game.contextInfo.componentTypes.Contains(typeof(IDComponent)))
        {
            _contexts.game.OnEntityCreated += AddId;
        }
        //}
    }

    public void TearDown ()
    {
        _contexts.game.RemoveCurrentID();

        //foreach (var context in _contexts.allContexts)
        //{
        if (_contexts.game.contextInfo.componentTypes.Contains(typeof(IDComponent)))
        {
            _contexts.game.OnEntityCreated -= AddId;
        }
        //}
    }

    private void AddId (IContext context, IEntity entity)
    {
        (entity as IIDEntity).AddID((uint)_contexts.game.currentID.value);
        _contexts.game.ReplaceCurrentID(_contexts.game.currentID.value + 1);
    }
}