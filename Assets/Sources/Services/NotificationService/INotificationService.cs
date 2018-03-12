using System;
using System.Collections.Generic;
using System.Linq;


public interface INotificationService
{
    int Schedule (string title, string message, int seconds);
    void CancelAll ();
    void Cancel (int id);
}

