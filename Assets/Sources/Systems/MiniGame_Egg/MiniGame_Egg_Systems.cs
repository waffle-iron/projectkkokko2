﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MiniGame_Egg_Systems : Feature
{
    public MiniGame_Egg_Systems (Contexts contexts) : base("Mini Game Egg Systems")
    {
        //Add(system here);
        Add(new MiniGameEgg_ResetReactiveSystem(contexts));
        Add(new MiniGameEgg_SetupGameReactiveSystem(contexts));
        Add(new Minigame_Egg_StartGameReactiveSystem(contexts));
        Add(new Minigame_Egg_ShootReactiveSystem(contexts));
        Add(new MiniGame_Egg_ShootExecuteSystem(contexts));
        Add(new MiniGame_Egg_Shoot_OnCollideReactiveSystem(contexts));
        Add(new MiniGame_Egg_MissedReactiveSystem(contexts));
        Add(new MiniGame_Egg_ScoredReactiveSystem(contexts));
    }
}