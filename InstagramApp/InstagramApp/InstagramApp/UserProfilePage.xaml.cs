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
    public partial class UserProfilePage : ContentPage
    {
        private UserService _user = new UserService();
        public UserProfilePage(int userId)
        {
            BindingContext = _user.GetUser(userId);

            InitializeComponent();

            
        }             
    }
}