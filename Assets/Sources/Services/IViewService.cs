using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IViewService
{
    void Load (IEntity entity, string name);
    void Refresh (string path, bool includeSceneObjects);
}

