using RecentSearches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecentSearches
{
    public class SearchService
    {   
        //private list with hard-coded search data - this is what you'll replace when you pull data from an outside server
        private List<Search> _searches = new List<Search> 
        {   
            new Search { Id = 1, Location = "West Hollywood, CA, United States", CheckIn = new DateTime(2016, 09, 27), CheckOut = new DateTime(2016, 10, 04)},
            new Search { Id = 2, Location = "Santa Monica, CA, United States", CheckIn = new DateTime(2016, 08, 15), CheckOut = new DateTime(2016, 09, 26)}
        };

        public IEnumerable<Search> GetRecentSearches(string filter = null)
        {
            //initialize a new list for searches
            if (string.IsNullOrWhiteSpace(filter))
            {
                return _searches;
            }

            return _searches.Where(c => c.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase)); //how to turn this into case insensitive

        }
        //Delete the search
        public void DeleteSearch(int searchId)
        {
            //delete the search result with the specific id
            _searches.Remove(_searches.Single(s => s.Id == searchId));
        }
    }
}
