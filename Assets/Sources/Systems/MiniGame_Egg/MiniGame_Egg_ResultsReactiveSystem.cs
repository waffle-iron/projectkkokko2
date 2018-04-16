using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class MiniGame_Egg_ResultsReactiveSystem : ReactiveSystem<GameEntity>
{
    private const string RESULTS_DIALOG = "minigame_egg_results";
    private readonly GameContext _game;
    private readonly InputContext _input;

    public MiniGame_Egg_ResultsReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _game = contexts.game;
        _input = contexts.input;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.GameState);
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasGameState && entity.gameState.current.IsEqualTo(MiniGameEggState.RESULTS);
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //open results dialog
            var inputEty = _input.CreateEntity();
            inputEty.AddActiveDialog(RESULTS_DIALOG);

            var saveWalletEntity = _input.CreateEntity();
            saveWalletEntity.AddTargetEntityID(_game.walletEntity.iD.value);
            saveWalletEntity.isSave = true;

            var saveTopScoreEntity = _input.CreateEntity();
            saveTopScoreEntity.AddTargetEntityID(_game.topScoreEntity.iD.value);
            saveTopScoreEntity.isSave = true;
        }
    }
}