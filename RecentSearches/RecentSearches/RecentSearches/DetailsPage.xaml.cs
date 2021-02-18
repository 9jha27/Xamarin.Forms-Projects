using RecentSearches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecentSearches
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Search search)
        {
            if (search == null) { throw new ArgumentNullException(); }
            InitializeComponent();

            BindingContext = search;
        }
    }
}