using Entitas;

public class Generic_CancelAction : UIAction
{
    public override void Execute (IEntity dialogEntity, Contexts contexts)
    {
        var inputEty = contexts.input.CreateEntity();
        var _id = ((GameEntity)dialogEntity).dialog.id;
        inputEty.AddDeactivateDialog(_id);
        inputEty.AddDelayDestroy(1);
    }
}

