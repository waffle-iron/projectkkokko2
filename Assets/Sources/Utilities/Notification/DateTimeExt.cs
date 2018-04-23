using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DateTimeFix
{

    public static class DateTimeExt
    {
#if UNITY_ANDROID && NET_4_6 && !UNITY_EDITOR
        static int cachedOffset = 0;
#endif
        static int MillisecondsOffset
        {
            get {
#if !UNITY_ANDROID || !NET_4_6 || UNITY_EDITOR
                return 0;
#else
                if(cachedOffset == 0)
                {
                    var calendar = new AndroidJavaObject("java.util.GregorianCalendar");
                    var timeZone = calendar.Call<AndroidJavaObject>("getTimeZone");
                    cachedOffset = timeZone.Call<int>("getRawOffset");
                }
                return cachedOffset;
#endif
            }
        }

        /// <summary>
        /// The latest versions of Unity running .NET rutime 4.6 on Android have a defect that
        /// local times get reported as UTC and no timezone information is available.
        /// 
        /// WARNING: do not call this function during app startup, such as initializing fields
        /// in classes.
        /// </summary>
        /// <param name="utcTime"></param>
        /// <returns></returns>
        public static DateTime FixTime (this DateTime time)
        {
            if (time.Kind == DateTimeKind.Local)
            {
                return time.AddMilliseconds(MillisecondsOffset);
            }
            else if (time.Kind == DateTimeKind.Utc)
            {
                return time.AddMilliseconds(-MillisecondsOffset);
            }
            else
            {
                return time;
            }
        }

        public static DateTime? FixTime (this DateTime? time)
        {
            return time?.FixTime();
        }
    }
}