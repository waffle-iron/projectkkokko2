using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using Entitas;

public class LimitSoapExecuteSystem : IExecuteSystem
{
    private IGroup<GameEntity> _soap;
    public LimitSoapExecuteSystem (Contexts contexts)
    {
        _soap = contexts.game.GetGroup(GameMatcher.Soap);
    }

    public void Execute ()
    {
        var soap = _soap.GetEntities();
        if (soap.Length > 1)
        {
            for (int idx = 0; idx < soap.Length - 1; idx++)
            {
                soap[idx].isToDestroy = true;
            }
        }
    }
}