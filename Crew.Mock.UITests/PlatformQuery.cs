using System;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Crew.Mock.UITests
{
    public class PlatformQuery
    {
        public Query Both
        {
            set
            {
                current = value;
            }
        }

        public Query Android
        {
            set
            {
                if (AppManager.Platform == Platform.Android)
                    current = value;
            }
        }

        public Query iOS
        {
            set
            {
                if (AppManager.Platform == Platform.iOS)
                    current = value;
            }
        }

        Query current;
        public Query Current
        {
            get
            {
                if (current == null)
                    throw new NullReferenceException("Trait not set for current platform");

                return current;
            }
        }
    }
}
