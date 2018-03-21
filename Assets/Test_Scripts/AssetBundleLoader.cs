using AssetBundles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UniRx;
using UnityEngine;

public static class AssetBundleLoader
{

    public static IEnumerator Init (string uri, IObserver<AssetBundleManager> observer, CancellationToken token)
    {
        var manager = new AssetBundleManager();
        manager.SetPrioritizationStrategy(AssetBundleManager.PrioritizationStrategy.PrioritizeStreamingAssets);
        if (uri != null) { manager.SetBaseUri(uri); }
        else { manager.UseStreamingAssetsFolder(); }

        var asyncInit = manager.InitializeAsync();
        yield return asyncInit;

        if (token.IsCancellationRequested) { yield break; }

        if (asyncInit.Success == false) { observer.OnError(new Exception("initialization failed;")); }
        else
        {
            Debug.Log("loaded manager");
            observer.OnNext(manager);
            observer.OnCompleted();
        }
    }

    public static IEnumerator LoadBundle (AssetBundleManager manager, string bundle, IObserver<AssetBundle> observer, CancellationToken token)
    {
        return LoadBundle(manager, new string[] { bundle }, observer, token);
    }
    public static IEnumerator LoadBundle (AssetBundleManager manager, string[] bundles, IObserver<AssetBundle> observer, CancellationToken token)
    {
        foreach (var bundle in bundles)
        {
            var loadedBundle = manager.GetBundleAsync(bundle);
            yield return loadedBundle;

            if (token.IsCancellationRequested) { yield break; }

            if (loadedBundle.AssetBundle == null) { Debug.LogError($"bundle {bundle} not found"); }
            else
            {
                Debug.Log($"loaded bundle {loadedBundle.AssetBundle.name}");
                observer.OnNext(loadedBundle.AssetBundle);
            }

            if (token.IsCancellationRequested) { yield break; }
        }
        observer.OnCompleted();
    }

    public static IObservable<T> LoadAsset<T> (AssetBundle bundle, string[] names) where T : UnityEngine.Object
    {
        var requests = new List<AssetBundleRequest>();

        foreach (var name in names)
        {
            requests.Add(bundle.LoadAssetAsync<T>(name));
        }

        return requests.ToObservable()
                    .Select(request => request.AsAsyncOperationObservable())
                    .Merge()
                    .Where(request => request.isDone)
                    .Select(request => request.asset as T);
    }
    public static IObservable<T[]> LoadAllAssetsArray<T> (AssetBundle bundle) where T : UnityEngine.Object
    {
        var loadStream = bundle.LoadAllAssetsAsync<T>().AsAsyncOperationObservable()
                            .Where(request => request.isDone)
                            .Select(request =>
                            {
                                return request.allAssets.Select(obj => obj as T).ToArray();
                            });

        return loadStream;
    }
    public static IObservable<T> LoadAllAssets<T> (AssetBundle bundle) where T : UnityEngine.Object
    {
        var loadStream = bundle.LoadAllAssetsAsync<T>().AsAsyncOperationObservable()
                            .Where(request => request.isDone)
                            .SelectMany(request =>
                            {
                                return request.allAssets.Select(obj => obj as T).ToArray();
                            });

        return loadStream;
    }
}

