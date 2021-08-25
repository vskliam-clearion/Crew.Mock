using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace Crew.Mock.UITests
{
    public class Tests : BaseTestFixture
    {
        public Tests(Platform platform) : base(platform)
        {

        }

        [Test]
        public void AppNavigatesToAccounts()
        {
            app.Tap("Enter App Code");

            var result = app.WaitForElement(c => c.Marked("addNewAccButton"));

            Assert.IsTrue(result.Any());
        }

        [Test]
        public void AppNavigatesToProjects()
        {
            app.WaitForElement(c => c.Marked("enterAppCodeButton"));
            app.Tap(c => c.Marked("enterAppCodeButton"));

            app.WaitForElement(c => c.Marked("addNewAccButton"));
            app.Tap(c => c.Marked("addNewAccButton"));

            app.WaitForElement(c => c.Marked("openAccButton"));
            app.Tap(c => c.Marked("openAccButton"));

            app.WaitForElement(c => c.Marked("projectsPage"));
        }
    }
}
