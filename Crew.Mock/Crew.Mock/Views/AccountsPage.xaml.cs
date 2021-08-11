using Crew.Mock.Helpers;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crew.Mock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountsPage : ContentPage
    {
        private static readonly Random Random = new Random();

        public AccountsPage()
        {
            InitializeComponent();
        }

        private void AddNewAccountButtonClicked(object sender, EventArgs e)
        {
            try
            {
                AppCenterHelper.TrackEvent(nameof(AddNewAccountButtonClicked));

                if (Random.Next(1, 4) == 1)
                {
                    throw new Exception("Failed to add Account");
                }

                AppCenterHelper.TrackEvent("Account Added Successfully");

                openAccButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                AppCenterHelper.TrackException(ex);
            }
        }

        private async void OpenAccountButtonClicked(object sender, EventArgs e)
        {
            AppCenterHelper.TrackEvent(nameof(OpenAccountButtonClicked));
            await Navigation.PushModalAsync(new ProjectsPage());
        }
    }
}