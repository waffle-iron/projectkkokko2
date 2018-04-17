//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class EventSystems : Feature {

    public EventSystems(Contexts contexts) {
        Add(new AcceptableRangeEventSystem(contexts)); // priority: 0
        Add(new GameAccessoryEventSystem(contexts)); // priority: 0
        Add(new InputAccessoryEventSystem(contexts)); // priority: 0
        Add(new CommandAccessoryEventSystem(contexts)); // priority: 0
        Add(new GameActionEventSystem(contexts)); // priority: 0
        Add(new CommandActionEventSystem(contexts)); // priority: 0
        Add(new InputActionEventSystem(contexts)); // priority: 0
        Add(new GameActiveDialogEventSystem(contexts)); // priority: 0
        Add(new CommandActiveDialogEventSystem(contexts)); // priority: 0
        Add(new InputActiveDialogEventSystem(contexts)); // priority: 0
        Add(new GameActiveDialogRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandActiveDialogRemovedEventSystem(contexts)); // priority: 0
        Add(new InputActiveDialogRemovedEventSystem(contexts)); // priority: 0
        Add(new GameAffordEventSystem(contexts)); // priority: 0
        Add(new InputAffordEventSystem(contexts)); // priority: 0
        Add(new CommandAffordEventSystem(contexts)); // priority: 0
        Add(new GameConsumingEventSystem(contexts)); // priority: 0
        Add(new InputConsumingEventSystem(contexts)); // priority: 0
        Add(new CommandConsumingEventSystem(contexts)); // priority: 0
        Add(new GameConsumingRemovedEventSystem(contexts)); // priority: 0
        Add(new InputConsumingRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandConsumingRemovedEventSystem(contexts)); // priority: 0
        Add(new GameCurrentEventSystem(contexts)); // priority: 0
        Add(new CommandCurrentEventSystem(contexts)); // priority: 0
        Add(new InputCurrentEventSystem(contexts)); // priority: 0
        Add(new CurrentRangeEventSystem(contexts)); // priority: 0
        Add(new GameDebugEventSystem(contexts)); // priority: 0
        Add(new InputDebugEventSystem(contexts)); // priority: 0
        Add(new CommandDebugEventSystem(contexts)); // priority: 0
        Add(new DurationEventSystem(contexts)); // priority: 0
        Add(new GameEquippedEventSystem(contexts)); // priority: 0
        Add(new InputEquippedEventSystem(contexts)); // priority: 0
        Add(new CommandEquippedEventSystem(contexts)); // priority: 0
        Add(new GameEquippedRemovedEventSystem(contexts)); // priority: 0
        Add(new InputEquippedRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandEquippedRemovedEventSystem(contexts)); // priority: 0
        Add(new GameFoodEventSystem(contexts)); // priority: 0
        Add(new CommandFoodEventSystem(contexts)); // priority: 0
        Add(new InputFoodEventSystem(contexts)); // priority: 0
        Add(new GameGameStateEventSystem(contexts)); // priority: 0
        Add(new CommandGameStateEventSystem(contexts)); // priority: 0
        Add(new InputGameStateEventSystem(contexts)); // priority: 0
        Add(new HitEventSystem(contexts)); // priority: 0
        Add(new HitRangeStatusEventSystem(contexts)); // priority: 0
        Add(new HudEventSystem(contexts)); // priority: 0
        Add(new GameLoadedViewsCompleteEventSystem(contexts)); // priority: 0
        Add(new InputLoadedViewsCompleteEventSystem(contexts)); // priority: 0
        Add(new CommandLoadedViewsCompleteEventSystem(contexts)); // priority: 0
        Add(new GameLoadedViewsCompleteRemovedEventSystem(contexts)); // priority: 0
        Add(new InputLoadedViewsCompleteRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandLoadedViewsCompleteRemovedEventSystem(contexts)); // priority: 0
        Add(new LoadEntitiesCompleteEventSystem(contexts)); // priority: 0
        Add(new LoadEntitiesCompleteRemovedEventSystem(contexts)); // priority: 0
        Add(new LoadingEventSystem(contexts)); // priority: 0
        Add(new LoadingRemovedEventSystem(contexts)); // priority: 0
        Add(new InputLoadSceneEventSystem(contexts)); // priority: 0
        Add(new CommandLoadSceneEventSystem(contexts)); // priority: 0
        Add(new GameLoadSceneEventSystem(contexts)); // priority: 0
        Add(new InputLoadSceneRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandLoadSceneRemovedEventSystem(contexts)); // priority: 0
        Add(new GameLoadSceneRemovedEventSystem(contexts)); // priority: 0
        Add(new InputLoadSceneCompleteEventSystem(contexts)); // priority: 0
        Add(new CommandLoadSceneCompleteEventSystem(contexts)); // priority: 0
        Add(new GameLoadSceneCompleteEventSystem(contexts)); // priority: 0
        Add(new InputLoadViewsEventSystem(contexts)); // priority: 0
        Add(new CommandLoadViewsEventSystem(contexts)); // priority: 0
        Add(new GameLoadViewsEventSystem(contexts)); // priority: 0
        Add(new InputLoadViewsRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandLoadViewsRemovedEventSystem(contexts)); // priority: 0
        Add(new GameLoadViewsRemovedEventSystem(contexts)); // priority: 0
        Add(new MissEventSystem(contexts)); // priority: 0
        Add(new GameMoveableEventSystem(contexts)); // priority: 0
        Add(new CommandMoveableEventSystem(contexts)); // priority: 0
        Add(new InputMoveableEventSystem(contexts)); // priority: 0
        Add(new GameNeedEventSystem(contexts)); // priority: 0
        Add(new InputNeedEventSystem(contexts)); // priority: 0
        Add(new CommandNeedEventSystem(contexts)); // priority: 0
        Add(new GameOnCollisionEventSystem(contexts)); // priority: 0
        Add(new InputOnCollisionEventSystem(contexts)); // priority: 0
        Add(new CommandOnCollisionEventSystem(contexts)); // priority: 0
        Add(new GamePauseEventSystem(contexts)); // priority: 0
        Add(new InputPauseEventSystem(contexts)); // priority: 0
        Add(new CommandPauseEventSystem(contexts)); // priority: 0
        Add(new GamePauseRemovedEventSystem(contexts)); // priority: 0
        Add(new InputPauseRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandPauseRemovedEventSystem(contexts)); // priority: 0
        Add(new GamePrePurchaseEventSystem(contexts)); // priority: 0
        Add(new CommandPrePurchaseEventSystem(contexts)); // priority: 0
        Add(new InputPrePurchaseEventSystem(contexts)); // priority: 0
        Add(new GamePreviewEventSystem(contexts)); // priority: 0
        Add(new InputPreviewEventSystem(contexts)); // priority: 0
        Add(new CommandPreviewEventSystem(contexts)); // priority: 0
        Add(new GamePreviewRemovedEventSystem(contexts)); // priority: 0
        Add(new InputPreviewRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandPreviewRemovedEventSystem(contexts)); // priority: 0
        Add(new GamePriceEventSystem(contexts)); // priority: 0
        Add(new InputPriceEventSystem(contexts)); // priority: 0
        Add(new CommandPriceEventSystem(contexts)); // priority: 0
        Add(new GamePurchasedEventSystem(contexts)); // priority: 0
        Add(new InputPurchasedEventSystem(contexts)); // priority: 0
        Add(new CommandPurchasedEventSystem(contexts)); // priority: 0
        Add(new GameRemoveFromStorageEventSystem(contexts)); // priority: 0
        Add(new InputRemoveFromStorageEventSystem(contexts)); // priority: 0
        Add(new CommandRemoveFromStorageEventSystem(contexts)); // priority: 0
        Add(new GameRemoveFromStorageRemovedEventSystem(contexts)); // priority: 0
        Add(new InputRemoveFromStorageRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandRemoveFromStorageRemovedEventSystem(contexts)); // priority: 0
        Add(new ReturnableEventSystem(contexts)); // priority: 0
        Add(new ReturnableRemovedEventSystem(contexts)); // priority: 0
        Add(new SavingEventSystem(contexts)); // priority: 0
        Add(new SavingRemovedEventSystem(contexts)); // priority: 0
        Add(new ScoreEventSystem(contexts)); // priority: 0
        Add(new SleepEventSystem(contexts)); // priority: 0
        Add(new SleepRemovedEventSystem(contexts)); // priority: 0
        Add(new GameSoapEventSystem(contexts)); // priority: 0
        Add(new CommandSoapEventSystem(contexts)); // priority: 0
        Add(new InputSoapEventSystem(contexts)); // priority: 0
        Add(new TargetDirectionCheckResultEventSystem(contexts)); // priority: 0
        Add(new GameTargetMoveEventSystem(contexts)); // priority: 0
        Add(new InputTargetMoveEventSystem(contexts)); // priority: 0
        Add(new CommandTargetMoveEventSystem(contexts)); // priority: 0
        Add(new GameToDestroyEventSystem(contexts)); // priority: 0
        Add(new InputToDestroyEventSystem(contexts)); // priority: 0
        Add(new CommandToDestroyEventSystem(contexts)); // priority: 0
        Add(new MetaToDestroyEventSystem(contexts)); // priority: 0
        Add(new GameToDestroyRemovedEventSystem(contexts)); // priority: 0
        Add(new InputToDestroyRemovedEventSystem(contexts)); // priority: 0
        Add(new CommandToDestroyRemovedEventSystem(contexts)); // priority: 0
        Add(new MetaToDestroyRemovedEventSystem(contexts)); // priority: 0
        Add(new TopScoreEventSystem(contexts)); // priority: 0
        Add(new GameTouchDataEventSystem(contexts)); // priority: 0
        Add(new CommandTouchDataEventSystem(contexts)); // priority: 0
        Add(new InputTouchDataEventSystem(contexts)); // priority: 0
        Add(new GameTriggerEventSystem(contexts)); // priority: 0
        Add(new CommandTriggerEventSystem(contexts)); // priority: 0
        Add(new InputTriggerEventSystem(contexts)); // priority: 0
        Add(new ValidGridEventSystem(contexts)); // priority: 0
        Add(new ValidGridRemovedEventSystem(contexts)); // priority: 0
        Add(new VelocityEventSystem(contexts)); // priority: 0
        Add(new ViewEventSystem(contexts)); // priority: 0
        Add(new ViewRemovedEventSystem(contexts)); // priority: 0
        Add(new GameWalletEventSystem(contexts)); // priority: 0
        Add(new InputWalletEventSystem(contexts)); // priority: 0
        Add(new CommandWalletEventSystem(contexts)); // priority: 0
        Add(new WipeEventSystem(contexts)); // priority: 0
    }
}
