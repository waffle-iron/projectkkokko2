using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

class UnityLoadSceneService : ILoadSceneService
{
    private const string ROOT_SCENE = "Start_Scene";

    private InputContext _input;

    private bool isDoneLoading = false;
    private bool isDoneUnloading = false;
    private bool isAlreadyLoading = false;

    private string sceneToLoad;

    public UnityLoadSceneService (Contexts contexts)
    {
        _input = contexts.input;
    }

    public void LoadScene (string name)
    {
        if (isAlreadyLoading) { return; }

        isAlreadyLoading = true;
        sceneToLoad = name;

        var loading = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        loading.allowSceneActivation = true;
        loading.completed += Loading_completed;

        var activeScene = SceneManager.GetActiveScene();

        if (activeScene.name.Equals(ROOT_SCENE) == false)
        {
            var unloading = SceneManager.UnloadSceneAsync(activeScene.name);
            unloading.allowSceneActivation = true;
            unloading.completed += Unloading_completed;
        }
        else
        {
            isDoneUnloading = true; 
        }

    }

    private void Unloading_completed (AsyncOperation obj)
    {
        isDoneUnloading = true;
        Check();
    }

    private void Loading_completed (AsyncOperation obj)
    {
        isDoneLoading = true;
        Check();
    }

    void Check ()
    {
        if (isDoneLoading && isDoneUnloading)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));
            isAlreadyLoading = false;

            _input.CreateEntity().isLoadSceneComplete = true;
        }
    }
}

