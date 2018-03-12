using System;
using System.Collections.Generic;
using System.Linq;


public class UltimateMobileNotificationService : INotificationService
{
    public UltimateMobileNotificationService ()
    {
    }

    public void Cancel (int id)
    {
        UM_NotificationController.Instance.CancelLocalNotification(id);
    }

    public void CancelAll ()
    {
        UM_NotificationController.Instance.CancelAllLocalNotifications();
    }

    public int Schedule (string title, string message, int seconds)
    {
        return UM_NotificationController.Instance.ScheduleLocalNotification(title, message, seconds);
    }
}

