using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuotesApp
{
    public partial class MainPage : ContentPage
    {
        //initialize a new list with a list of quotes
        List<string> quote = new List<string>()
        {
            "this is quote one",
            "this is quote two",
            "this is quote three"
        };
        

        public MainPage()
        {


            InitializeComponent();


            slider.Value = 16;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //instantiate a new random object
            Random rand = new Random();
            //Generate a random index less than the number of quotes in the list
            int index = rand.Next(quote.Count);
            Quotes.Text = quote[index];
        }
    }
}
