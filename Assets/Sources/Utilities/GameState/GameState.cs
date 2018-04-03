using System;

public struct GameState
{
    public int state;
    public System.Type type;

    public GameState (int state, System.Type type)
    {
        this.state = state;
        this.type = type;
    }
}

