using Entitas;

public interface ITrigger
{
    bool Check (IEntity entity, Contexts contexts);
}

