using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crew.Mock.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectsPage : ContentPage
    {
        public ProjectsPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Crashes.GenerateTestCrash();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            throw new Exception("Exception happened");
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Exception happened");
            }
            catch (Exception ex)
            {
                Helpers.AppCenterHelper.TrackException(ex);
            }
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Exception happened");
            }
            catch (Exception ex)
            {
                var additionalInformation = new Dictionary<string, string>()
                {
                    { "Network Access", Connectivity.NetworkAccess.ToString() },
                };

                Helpers.AppCenterHelper.TrackException(ex, additionalInformation);
            }
        }
    }
}