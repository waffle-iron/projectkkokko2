using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;
using AssetBundles;
using System.Threading;

public class AssetBundle_Test : MonoBehaviour
{
    [SerializeField]
    private string[] _bundles;

    [SerializeField]
    private string[] _objs;

    [SerializeField]
    List<GameObject> _pool = new List<GameObject>();

    [SerializeField]
    private List<AssetBundle> _loaded = new List<AssetBundle>();

    private AssetBundleManager manager;

    private void Start ()
    {
        //init manager
        var loader = new AssetBundleLoader(_bundles, _objs);
    }

    
}
