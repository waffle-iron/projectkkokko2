using Entitas;
using System;
using System.Collections.Generic;


public interface IEntityService
{
    bool Get (string name, out IEntity entity);
    bool Get (string name);
    bool Add (IEntityConfig config);
}

