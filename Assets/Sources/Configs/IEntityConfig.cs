using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;


public interface IEntityConfig
{
    string Name { get; }
    IEntity Create ();
}

