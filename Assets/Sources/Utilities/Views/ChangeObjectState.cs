using UnityEngine;
using System.Collections;

public class ChangeObjectState : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private MainGameState _newState;

    [SerializeField]
    private bool _activate = true;

    public void OnClick ()
    {
        _target.SetActive(_activate);

        if (_newState != MainGameState.NONE)
        {
            var input = Contexts.sharedInstance.input.CreateEntity();
            input.AddGameState(new GameState((int)_newState, typeof(MainGameState)));
        }
    }
}
