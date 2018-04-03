using Entitas;

public interface ITrigger
{
    bool Check (IEntity entity, IContext context);
}

