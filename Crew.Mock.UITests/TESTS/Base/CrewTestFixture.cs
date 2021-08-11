using Crew.Mock.UITests.Helpers;
using Crew.Mock.UITests.Pages;
using Crew.Mock.UITests.Tests.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Xamarin.UITest;

namespace Crew.Mock.UITests.Tests.Base
{
    public class CrewTestFixture : BaseTestFixture
    {
        public static IEnumerable<TestConfiguration> AppCodeMultiple
        {
            get
            {
                yield return new TestConfiguration("productdev");
                yield return new TestConfiguration("PRODUCTDEV");
            }
        }

        public static IEnumerable<TestConfiguration> Product_Dev_Assessment
        {
            get
            {
                yield return new TestConfiguration("productdev", "Clearion AGOL", "slavic_clearion", "Edge530909", "UVM Assessment");
            }
        }
        public static IEnumerable<TestConfiguration> Product_Dev_Crew
        {
            get
            {
                yield return new TestConfiguration("productdev", "Clearion AGOL", "slavic_clearion", "Edge530909", "UVM Crew");
            }
        }

        public CrewTestFixture(Platform platform) : base(platform)
        {

        }

        public void Repl()
        {
            if (TestEnvironment.IsTestCloud)
                Assert.Ignore();

            app.Repl();
        }
    }
}
