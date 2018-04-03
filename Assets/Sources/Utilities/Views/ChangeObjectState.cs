using UnityEngine;
using System.Collections;

public class ChangeObjectState : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private GameState _newState;

    [SerializeField]
    private bool _activate = true;

    public void OnClick ()
    {
        _target.SetActive(_activate);

        if (_newState != GameState.NONE)
        {
            var input = Contexts.sharedInstance.input.CreateEntity();
            input.AddGameState((int)_newState, typeof(GameState));
        }
    }
}
