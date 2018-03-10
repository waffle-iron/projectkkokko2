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
    public readonly IPauseService pause;
    public readonly INotificationService notif;

    public Services 
        (
            ILoadSceneService scene,
            IViewService view,
            ISavingService save,
            ITimeService time,
            IEntityService entity,
            IPauseService pause,
            INotificationService notif
        )
    {
        this.scene = scene;
        this.view = view;
        this.save = save;
        this.time = time;
        this.entity = entity;
        this.pause = pause;
        this.notif = notif;
    }
}
