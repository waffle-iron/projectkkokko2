using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class DurationTypeExtensions
{
    public static float GetInSeconds(this DurationType duration)
    {
        switch (duration.unit)
        {
            default:
            case UnitTime.Second:
                return duration.length;
            case UnitTime.Minute:
                return (float)TimeSpanUtil.ConvertMinutesToSeconds(duration.length);
            case UnitTime.Hour:
                return (float)TimeSpanUtil.ConvertHoursToSeconds(duration.length);
            case UnitTime.Day:
                return (float)TimeSpanUtil.ConvertDaysToSeconds(duration.length);
        }

    }

    public static float GetInMinutes(this DurationType duration)
    {
        switch (duration.unit)
        {
            case UnitTime.Second:
                return (float)TimeSpanUtil.ConvertSecondsToMinutes(duration.length);
            default:
            case UnitTime.Minute:
                return duration.length;
            case UnitTime.Hour:
                return (float)TimeSpanUtil.ConvertHoursToMinutes(duration.length);
            case UnitTime.Day:
                return (float)TimeSpanUtil.ConvertDaysToMinutes(duration.length);
        }
    }

    public static float GetInHours(this DurationType duration)
    {
        switch (duration.unit)
        {
            case UnitTime.Second:
                return (float)TimeSpanUtil.ConvertSecondsToHours(duration.length);
            case UnitTime.Minute:
                return (float)TimeSpanUtil.ConvertMinutesToHours(duration.length);
            default:
            case UnitTime.Hour:
                return duration.length;
            case UnitTime.Day:
                return (float)TimeSpanUtil.ConvertDaysToHours(duration.length);
        }
    }

    public static float GetInDays(this DurationType duration)
    {
        switch (duration.unit)
        {
            case UnitTime.Second:
                return (float)TimeSpanUtil.ConvertSecondsToDays(duration.length);
            case UnitTime.Minute:
                return (float)TimeSpanUtil.ConvertMinutesToDays(duration.length);
            case UnitTime.Hour:
                return (float)TimeSpanUtil.ConvertHoursToDays(duration.length);
            default:
            case UnitTime.Day:
                return duration.length;
        }
    }
}
