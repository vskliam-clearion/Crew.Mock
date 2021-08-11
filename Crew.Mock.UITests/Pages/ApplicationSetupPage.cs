using Crew.Mock.UITests.Helpers;
using Crew.Mock.UITests.Pages.Base;
using NUnit.Framework;
using System.Linq;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Crew.Mock.UITests.Pages
{
    public class ApplicationSetupPage : CrewBasePage
    {
        private readonly Query entry;
        private readonly Query loginButton;
        private readonly Query errorLabel;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Both = x => x.Marked(AID.ApplicationSetupPage)
        };

        public ApplicationSetupPage()
        {
            entry = x => x.Marked(AID.ApplicationSetupAppCodeEntry);
            loginButton = x => x.Marked(AID.ApplicationSetupLoginButton);
            errorLabel = x => x.Marked(AID.ApplicationSetupErrorLabel);
        }

        public ApplicationSetupPage EnterApplicationCode(string code)
        {
            App.WaitForElement(entry);
            App.EnterText(entry, code);
            App.DismissKeyboard();
            App.Screenshot($"Application code \"{code}\" entered");

            return this;
        }

        public ApplicationSetupPage SubmitApplicationCode()
        {
            App.WaitForElement(loginButton);
            App.Tap(loginButton);

            return this;
        }

        public ApplicationSetupPage VerifyWrongCodeMessage()
        {
            App.WaitForElement(entry);

            var entryQuery = App.Query(entry);
            var entryValue = entryQuery?.FirstOrDefault()?.Text ?? string.Empty;

            var labelQuery = App.Query(errorLabel);
            var labelValue = labelQuery?.FirstOrDefault()?.Text ?? string.Empty;

            var expectedMessage = $"Unable to setup application for code: {entryValue}";

            StringAssert.AreEqualIgnoringCase(expectedMessage, labelValue);

            return this;
        }

        public ApplicationSetupPage VerifyNoInternetMessage()
        {

            var labelQuery = App.Query(errorLabel);
            var labelValue = labelQuery?.FirstOrDefault()?.Text ?? string.Empty;

            var expectedMessage = "No Internet Connection";

            StringAssert.AreEqualIgnoringCase(expectedMessage, labelValue);

            return this;
        }
    }
}
