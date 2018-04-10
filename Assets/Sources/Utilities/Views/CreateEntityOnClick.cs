using UnityEngine;
using System.Collections;
using Entitas;

public class CreateEntityOnClick : MonoBehaviour
{
    [SerializeField]
    private string _entity;

    [SerializeField]
    private bool _isToggle = false;

    private uint _id = 0;

    public void Execute ()
    {
        if (_isToggle)
        {
            if (_id != 0)
            {
                var ety = Contexts.sharedInstance.game.GetEntityWithID(_id);
                if (ety != null) { ety.isToDestroy = true; }
                _id = 0;
            }
            else
            {
                IEntity ety;
                Contexts.sharedInstance.meta.entityService.instance.Get(_entity, out ety);
                _id = ((IIDEntity)ety).iD.value;
            }
        }
        else
        {
            Contexts.sharedInstance.meta.entityService.instance.Get(_entity);
        }
    }
}
