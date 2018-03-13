using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SceneSwitcher : MonoBehaviour {

    [SceneName, SerializeField]
    private string target;

    private void Start ()
    {
        Contexts.sharedInstance.input.CreateEntity().AddLoadScene(target);
    }
}
