using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneViewsInitializer : MonoBehaviour
{
    [SerializeField]
    private string[] _paths;
    [SerializeField]
    private bool _includeSceneObjects;

    // Use this for initialization
    void Awake ()
    {
        var inputEntity = Contexts.sharedInstance.input.CreateEntity();
        inputEntity.AddLoadViews(_paths, _includeSceneObjects);
    }
}
