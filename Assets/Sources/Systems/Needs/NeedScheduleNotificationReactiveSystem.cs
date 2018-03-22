using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Entitas;
using System.Linq;

public class NeedScheduleNotificationReactiveSystem : ReactiveSystem<GameEntity>
{
    private readonly MetaContext _meta;
    private readonly IGroup<GameEntity> _notiData;

    public NeedScheduleNotificationReactiveSystem (Contexts contexts) : base(contexts.game)
    {
        _meta = contexts.meta;
        _notiData = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.TargetNeed, GameMatcher.NotificationMessage));
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context)
    {
        //return collector
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Timer, GameMatcher.Need));
    }

    protected override bool Filter (GameEntity entity)
    {
        // check for required components
        //Timer, Trigger, Notification Message, Interval
        return entity.hasNotificationScheduled == false &&
            entity.hasTimer &&
            entity.hasTrigger &&
            entity.hasInterval;
    }

    protected override void Execute (List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //get notification data
            var noti = _notiData.AsEnumerable().Where(n => n.targetNeed.type == e.need.type);

            //do nothing if no noti message is found
            if (noti == null || noti.Count() == 0) { continue; }

            //calculate for scheduled seconds
            int seconds = 0;

            if (e.trigger.state == false)
            {
                seconds += Mathf.CeilToInt(e.trigger.duration.GetInSeconds() - e.timer.current);
            }
            else
            {
                seconds += Mathf.CeilToInt(e.interval.duration.GetInSeconds() - e.timer.current);
            }

            var notiData = noti.Single().notificationMessage;
            seconds += notiData.offset;

            //schedule notification service
            var id = _meta.notificationService.instance.Schedule(notiData.title, notiData.message, seconds);
            e.AddNotificationScheduled(seconds, id);
        }
    }
}