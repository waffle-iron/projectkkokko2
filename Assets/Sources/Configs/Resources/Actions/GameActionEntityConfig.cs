using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;


public class GameActionEntityConfig : UnityEntityConfig
{
    protected override IEntity CustomCreate (Contexts contexts)
    {
        return contexts.game.CreateEntity();
    }
}

