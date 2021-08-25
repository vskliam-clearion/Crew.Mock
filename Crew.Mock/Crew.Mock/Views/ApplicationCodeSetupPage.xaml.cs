using Crew.Mock.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crew.Mock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationCodeSetupPage : ContentPage
    {
        public ApplicationCodeSetupPage()
        {
            InitializeComponent();
        }

        private async void EnterAppCodeButtonClicked(object sender, EventArgs e)
        {
            AppCenterHelper.TrackEvent(nameof(EnterAppCodeButtonClicked));
            await Navigation.PushModalAsync(new AccountsPage());
        }
    }
}