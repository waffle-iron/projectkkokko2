using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneViewsInitializer : MonoBehaviour
{
    [SerializeField]
    private string[] _paths;
    [SerializeField]
    private bool _includeSceneObjects;

    private bool _isInitialized = false;

    // Use this for initialization
    void Update ()
    {
        if (Contexts.sharedInstance.game.isLoadSceneComplete && _isInitialized == false)
        {
            var inputEntity = Contexts.sharedInstance.input.CreateEntity();
            inputEntity.AddLoadViews(_paths, _includeSceneObjects);
            _isInitialized = true;
            //Debug.Log($"loading views at {SceneManager.GetActiveScene().name}");
        }
    }
}
