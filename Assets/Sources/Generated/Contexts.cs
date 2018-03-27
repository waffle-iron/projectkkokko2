//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public CommandContext command { get; set; }
    public GameContext game { get; set; }
    public InputContext input { get; set; }
    public MetaContext meta { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { command, game, input, meta }; } }

    public Contexts() {
        command = new CommandContext();
        game = new GameContext();
        input = new InputContext();
        meta = new MetaContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string Accessory = "Accessory";
    public const string Food = "Food";
    public const string ID = "ID";
    public const string Need = "Need";
    public const string SceneInitConfig = "SceneInitConfig";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, string>(
            Accessory,
            game.GetGroup(GameMatcher.Accessory),
            (e, c) => ((AccessoryComponent)c).id));
        input.AddEntityIndex(new Entitas.PrimaryEntityIndex<InputEntity, string>(
            Accessory,
            input.GetGroup(InputMatcher.Accessory),
            (e, c) => ((AccessoryComponent)c).id));
        command.AddEntityIndex(new Entitas.PrimaryEntityIndex<CommandEntity, string>(
            Accessory,
            command.GetGroup(CommandMatcher.Accessory),
            (e, c) => ((AccessoryComponent)c).id));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, string>(
            Food,
            game.GetGroup(GameMatcher.Food),
            (e, c) => ((FoodComponent)c).id));
        command.AddEntityIndex(new Entitas.PrimaryEntityIndex<CommandEntity, string>(
            Food,
            command.GetGroup(CommandMatcher.Food),
            (e, c) => ((FoodComponent)c).id));
        input.AddEntityIndex(new Entitas.PrimaryEntityIndex<InputEntity, string>(
            Food,
            input.GetGroup(InputMatcher.Food),
            (e, c) => ((FoodComponent)c).id));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, uint>(
            ID,
            game.GetGroup(GameMatcher.ID),
            (e, c) => ((IDComponent)c).value));
        input.AddEntityIndex(new Entitas.PrimaryEntityIndex<InputEntity, uint>(
            ID,
            input.GetGroup(InputMatcher.ID),
            (e, c) => ((IDComponent)c).value));
        command.AddEntityIndex(new Entitas.PrimaryEntityIndex<CommandEntity, uint>(
            ID,
            command.GetGroup(CommandMatcher.ID),
            (e, c) => ((IDComponent)c).value));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, NeedType>(
            Need,
            game.GetGroup(GameMatcher.Need),
            (e, c) => ((NeedComponent)c).type));
        input.AddEntityIndex(new Entitas.PrimaryEntityIndex<InputEntity, NeedType>(
            Need,
            input.GetGroup(InputMatcher.Need),
            (e, c) => ((NeedComponent)c).type));
        command.AddEntityIndex(new Entitas.PrimaryEntityIndex<CommandEntity, NeedType>(
            Need,
            command.GetGroup(CommandMatcher.Need),
            (e, c) => ((NeedComponent)c).type));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, string>(
            SceneInitConfig,
            game.GetGroup(GameMatcher.SceneInitConfig),
            (e, c) => ((SceneInitConfigComponent)c).sceneName));
    }
}

public static class ContextsExtensions {

    public static GameEntity GetEntityWithAccessory(this GameContext context, string id) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.Accessory)).GetEntity(id);
    }

    public static InputEntity GetEntityWithAccessory(this InputContext context, string id) {
        return ((Entitas.PrimaryEntityIndex<InputEntity, string>)context.GetEntityIndex(Contexts.Accessory)).GetEntity(id);
    }

    public static CommandEntity GetEntityWithAccessory(this CommandContext context, string id) {
        return ((Entitas.PrimaryEntityIndex<CommandEntity, string>)context.GetEntityIndex(Contexts.Accessory)).GetEntity(id);
    }

    public static GameEntity GetEntityWithFood(this GameContext context, string id) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.Food)).GetEntity(id);
    }

    public static CommandEntity GetEntityWithFood(this CommandContext context, string id) {
        return ((Entitas.PrimaryEntityIndex<CommandEntity, string>)context.GetEntityIndex(Contexts.Food)).GetEntity(id);
    }

    public static InputEntity GetEntityWithFood(this InputContext context, string id) {
        return ((Entitas.PrimaryEntityIndex<InputEntity, string>)context.GetEntityIndex(Contexts.Food)).GetEntity(id);
    }

    public static GameEntity GetEntityWithID(this GameContext context, uint value) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, uint>)context.GetEntityIndex(Contexts.ID)).GetEntity(value);
    }

    public static InputEntity GetEntityWithID(this InputContext context, uint value) {
        return ((Entitas.PrimaryEntityIndex<InputEntity, uint>)context.GetEntityIndex(Contexts.ID)).GetEntity(value);
    }

    public static CommandEntity GetEntityWithID(this CommandContext context, uint value) {
        return ((Entitas.PrimaryEntityIndex<CommandEntity, uint>)context.GetEntityIndex(Contexts.ID)).GetEntity(value);
    }

    public static GameEntity GetEntityWithNeed(this GameContext context, NeedType type) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, NeedType>)context.GetEntityIndex(Contexts.Need)).GetEntity(type);
    }

    public static InputEntity GetEntityWithNeed(this InputContext context, NeedType type) {
        return ((Entitas.PrimaryEntityIndex<InputEntity, NeedType>)context.GetEntityIndex(Contexts.Need)).GetEntity(type);
    }

    public static CommandEntity GetEntityWithNeed(this CommandContext context, NeedType type) {
        return ((Entitas.PrimaryEntityIndex<CommandEntity, NeedType>)context.GetEntityIndex(Contexts.Need)).GetEntity(type);
    }

    public static GameEntity GetEntityWithSceneInitConfig(this GameContext context, string sceneName) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.SceneInitConfig)).GetEntity(sceneName);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContexObservers() {
        try {
            CreateContextObserver(command);
            CreateContextObserver(game);
            CreateContextObserver(input);
            CreateContextObserver(meta);
        } catch(System.Exception) {
        }
    }

    public void CreateContextObserver(Entitas.IContext context) {
        if (UnityEngine.Application.isPlaying) {
            var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
    }

#endif
}
