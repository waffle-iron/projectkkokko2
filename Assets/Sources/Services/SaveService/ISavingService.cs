using System;
using System.Collections.Generic;
using System.Linq;
using CodeStage.AntiCheat.ObscuredTypes;
using Entitas;

public interface ISavingService
{
    bool Save (ObscuredString id, IEntity entity);
    bool LoadNew (ObscuredString id, Contexts contexts);
    bool LoadExisting (ObscuredString id, IEntity entity);
}

