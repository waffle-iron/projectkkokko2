using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SceneSwitcher : MonoBehaviour {

    [SceneName, SerializeField]
    private string target;

    [SerializeField]
    private bool _changeOnStart = true;

    private void Start ()
    {
        if (_changeOnStart)
        {
            Execute();
        }
    }

    public void Execute ()
    {
        Contexts.sharedInstance.input.CreateEntity().AddLoadScene(target);
    }
}
