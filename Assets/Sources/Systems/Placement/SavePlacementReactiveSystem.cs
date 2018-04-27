using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;

public class SavePlacementReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly InputContext _input;
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _apartmentItems;

    public SavePlacementReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _input = contexts.input;
        _game = contexts.game;
        _apartmentItems = contexts.game.GetGroup(GameMatcher.ApartmentInstanceSaveID);
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TouchData, GameMatcher.Placeable));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTouchData &&
            entity.touchData.current.Phase == TouchPhase.Ended &&
            entity.hasPlaceablePosition;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        var saveData = _game.apartmentItemsInstanceData.data;

        foreach (var e in entities)
        {
            if (e.hasApartmentInstanceSaveID)
            {
                var savedPoss = saveData[e.entityConfig.name];
                savedPoss[e.apartmentInstanceSaveID.id] = e.placeablePosition.current;
            }
            else
            {
                //Dictionary<entityCfgId, Dictionary<AptItemID+Index, Position>>
                if (saveData.ContainsKey(e.entityConfig.name) == false)
                {
                    saveData.Add(e.entityConfig.name, new Dictionary<string, Vector3>());
                }

                var savedPoss = saveData[e.entityConfig.name];
                var id = e.entityConfig.name + savedPoss.Keys.Count;
                if (savedPoss.ContainsKey(id))
                {
                    savedPoss[id] = e.placeablePosition.current;
                }
                else
                {
                    savedPoss.Add(id, e.placeablePosition.current);
                }
                e.AddApartmentInstanceSaveID(id);
            }
        }

        var inputety = _input.CreateEntity();
        inputety.AddTargetEntityID(_game.apartmentItemsInstanceDataEntity.iD.value);
        inputety.isSave = true;
    }
}