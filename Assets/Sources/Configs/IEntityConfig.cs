using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;

public interface IEntityConfig
{
    string srcPath { get; set; }
    EntityCfgID Name { get; }
    IEntity Create (Contexts contexts);
}

