using InstagramApp.Models;
using InstagramApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        private ActivityService _activityServices = new ActivityService();//initialize the AcitivityService class
        

        public ActivityPage()
        { 

            InitializeComponent();

            listView.ItemsSource = _activityServices.GetActivities();
        }

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }
            var user = e.SelectedItem as Activity;

            await Navigation.PushAsync(new NavigationPage(new UserProfilePage(user.UserId)));
            listView.SelectedItem = null;
        }
    }
}