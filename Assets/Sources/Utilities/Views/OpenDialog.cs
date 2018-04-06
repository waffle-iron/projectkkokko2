using UnityEngine;
using System.Collections;

public class OpenDialog : MonoBehaviour
{
    [SerializeField]
    private string _id;

    public void Execute ()
    {
        var inputEty = Contexts.sharedInstance.input.CreateEntity();
        inputEty.AddActiveDialog(_id);
    }
}
