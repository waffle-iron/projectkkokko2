using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SceneSwitcher : MonoBehaviour {

    [SceneName, SerializeField]
    private string target;

    [SerializeField]
    private float delay = -1f;

    private void Start ()
    {
        if (delay >= 0f)
        {
            Invoke("Execute", delay);
        }
    }

    public void Execute ()
    {
        Contexts.sharedInstance.input.CreateEntity().AddLoadScene(target);
    }
}
