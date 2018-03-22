using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;
using System.Linq;

public class NeedUnscheduleNotificationReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;
    private readonly IGroup<GameEntity> _notiData;

    public NeedUnscheduleNotificationReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
        _notiData = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.TargetNeed, GameMatcher.NotificationMessage));
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Timer, GameMatcher.Need, GameMatcher.NotificationScheduled));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        return entity.hasTimer && entity.hasNotificationScheduled;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            // do stuff to the matched entities
            //get notification data
            var noti = _notiData.AsEnumerable().Where(n => n.targetNeed.type == e.need.type);

            //do nothing if no noti message is found
            if (noti == null || noti.Count() == 0) { continue; }

            var notiData = noti.Single().notificationMessage;

            //cancel if it matches conditions
            if (e.notificationScheduled.seconds - notiData.offset <= e.timer.current)
            {
                _meta.notificationService.instance.Cancel(e.notificationScheduled.id);
                e.RemoveNotificationScheduled();
                Debug.Log($"unscheduled {e.notificationScheduled.id}");
            }
        }
    }
}