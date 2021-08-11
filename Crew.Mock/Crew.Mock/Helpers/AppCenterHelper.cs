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
    }
}
