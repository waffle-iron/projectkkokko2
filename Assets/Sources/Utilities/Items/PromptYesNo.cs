using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PromptYesNo : MonoBehaviour, IPrompt
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _prompt;

    Action _yes = null;
    Action _no = null;

    void Start ()
    {
        _prompt.SetActive(false);
    }

    public void Activate (Action yes, Action no, string message)
    {
        _yes = yes;
        _no = no;
        _text.text = message;
        _prompt.SetActive(true);
    }


    public void OnYes ()
    {
        if (_yes != null)
        {
            _yes.Invoke();
        }
        _prompt.SetActive(false);
    }

    public void OnNo ()
    {
        if (_no != null)
        {
            _no.Invoke();
        }
        _prompt.SetActive(false);
    }
}
