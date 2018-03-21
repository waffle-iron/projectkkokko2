using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class UnityLoadSceneServiceV2 : ILoadSceneService
{
    private string _rootScene;
    private Contexts _contexts;

    public UnityLoadSceneServiceV2 (Contexts contexts)
    {
        _rootScene = SceneManager.GetActiveScene().name;
        _contexts = contexts;
    }

    public string ActiveScene
    {
        get {
            return SceneManager.GetActiveScene().name;
        }
    }

    public void LoadScene (string name)
    {
        var activeScene = SceneManager.GetActiveScene();

        if (activeScene.name.Equals(_rootScene) == false)
        {
            UnloadCurrentScene().completed += (unloadResult) =>
            {
                LoadNewScene(name).completed += (loadResult) =>
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
                    _contexts.input.CreateEntity().isLoadSceneComplete = true;
                };
            };
        }
        else
        {
            LoadNewScene(name).completed += (loadResult) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
                _contexts.input.CreateEntity().isLoadSceneComplete = true;
            };
        }

    }

    private void Unloading_completed (AsyncOperation obj)
    {
    }

    AsyncOperation UnloadCurrentScene ()
    {
        var activeScene = SceneManager.GetActiveScene();
        var unloading = SceneManager.UnloadSceneAsync(activeScene.name);
        unloading.allowSceneActivation = true;
        return unloading;
    }

    AsyncOperation LoadNewScene (string name)
    {
        var loading = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        loading.allowSceneActivation = true;
        return loading;
    }
}
