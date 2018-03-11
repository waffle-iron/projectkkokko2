using Entitas;
using System;
using System.Collections.Generic;


public interface IEntityService
{
    bool Get (EntityCfgID name, out IEntity entity);
}

