using System;

public struct GameState
{
    public int state { get; private set; }
    public System.Type type { get; private set; }

    public GameState (ValueType state)
    {
        if (state.GetType().IsEnum == false) { UnityEngine.Debug.LogError("must be enum"); }
        this.state = (int)state;
        this.type = state.GetType();
    }

    public GameState(int state, System.Type type)
    {
        this.state = state;
        this.type = type;
    }
}

