using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;

namespace Crew.Mock.Helpers
{
    public static class AppCenterHelper
    {
        public static void TrackException(Exception exception, IDictionary<string, string> properties = null)
        {
            Crashes.TrackError(exception, properties);
        }

        public static void TrackEvent(string eventName, IDictionary<string, string> properties = null)
        {
            Analytics.TrackEvent(eventName, properties);
        }
    }
}
