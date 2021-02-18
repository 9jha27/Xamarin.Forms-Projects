
using RecentSearches.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecentSearches
{
    public partial class MainPage : ContentPage
    {
        private SearchService _searchServices; //initialize the SearchService class
        private List<SearchGroup> _searchGroups;

        public MainPage()
        {
            _searchServices = new SearchService();

            InitializeComponent();

            PopulateListView(_searchServices.GetRecentSearches());
            
        }

        private void PopulateListView(IEnumerable<Search> searches)
        {
            _searchGroups = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }

        //when the text changes in the search bar, do this
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateListView(_searchServices.GetRecentSearches(e.NewTextValue)); //text change event triggers the listView items to implement the GetSearches method to filter for the event's new text value
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

            var search = (sender as MenuItem).CommandParameter as Search;
            //this one removes it from the listview
            _searchGroups[0].Remove(search);
            //this method lnked to the SearchService class deletes data on the back end
            _searchServices.DeleteSearch(search.Id);
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            listView.EndRefresh();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }
    }
}
