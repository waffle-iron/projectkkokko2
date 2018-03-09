using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services
{
    public readonly ILoadSceneService scene;
    public readonly IViewService view;

    public Services 
        (
            ILoadSceneService scene,
            IViewService view
        )
    {
        this.scene = scene;
        this.view = view;
    }
}
