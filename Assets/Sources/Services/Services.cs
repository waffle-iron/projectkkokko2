using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services
{
    public readonly ILoadSceneService scene;
    public readonly IViewService view;
    public readonly ISavingService save;
    public readonly ITimeService time;
    public readonly IEntityService entity;

    public Services 
        (
            ILoadSceneService scene,
            IViewService view,
            ISavingService save,
            ITimeService time,
            IEntityService entity
        )
    {
        this.scene = scene;
        this.view = view;
        this.save = save;
        this.time = time;
        this.entity = entity;
    }
}
