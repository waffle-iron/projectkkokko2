using System;

public static class GameStateExtensions
{
    public static bool IsEqualTo (this GameState state, ValueType Enum)
    {
        return state.type == Enum.GetType() && state.state == (int)Enum;
    }
}

