using Crew.Mock.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace Crew.Mock
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ApplicationCodeSetupPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=bd628be0-b5fd-42d5-a545-316d31a9c0aa;" +
                "uwp=8746b46c-762f-4602-a21b-5d08270b094f;" +
                "ios=2c2cf119-8aee-496d-bae1-0df68dedeb00",
                typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
