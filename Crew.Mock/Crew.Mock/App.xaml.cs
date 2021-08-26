using Crew.Mock.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Crew.Mock.Helpers;

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
            AppCenter.Start("android=00a90f8d-b20a-4257-8386-683c16ccedeb;" +
                "uwp=984d8ad6-eba1-4ac4-8cb0-5fc2b53ee51f;" +
                "ios=26cce52a-f7a9-4269-ba2d-fa2df1a085ba",
                typeof(Analytics), typeof(Crashes));

            AppCenterHelper.TrackEvent("Application started");
        }

        protected override void OnSleep()
        {
            AppCenterHelper.TrackEvent("Application is on sleep");
        }

        protected override void OnResume()
        {
            AppCenterHelper.TrackEvent("Application resumed");
        }
    }
}
