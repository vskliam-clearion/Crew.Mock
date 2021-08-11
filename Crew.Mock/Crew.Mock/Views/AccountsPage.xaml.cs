
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crew.Mock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountsPage : ContentPage
    {
        public AccountsPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ProjectsPage());
        }
    }
}