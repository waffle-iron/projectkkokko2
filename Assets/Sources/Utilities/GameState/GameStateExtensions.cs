using System;

public static class GameStateExtensions
{
    public static bool Equals (this GameState state, ValueType Enum)
    {
        return state.type == typeof(Enum) && state.state == (int)Enum;
    }
}

