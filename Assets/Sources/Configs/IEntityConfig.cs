using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;

public interface IEntityConfig
{
    string SrcPath { get; set; }
    string Name { get; }
    IEntity Create (Contexts contexts);
}

