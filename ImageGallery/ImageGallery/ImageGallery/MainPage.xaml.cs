using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageGallery
{
    public partial class MainPage : ContentPage
    {
        private int _currentImageId = 143;

        public MainPage()
        {
            InitializeComponent();

            _currentImageId = 143;

            LoadImage();
        }

        void LoadImage()
        {
            image.Source = new UriImageSource 
            {
                Uri = new Uri(String.Format("https://picsum.photos/id/{0}/200/300", _currentImageId)),
                CachingEnabled = false
            };

        }    

        private void previous_Clicked(object sender, EventArgs e)
        {
            _currentImageId--;

            LoadImage();
        }

        private void next_Clicked(object sender, EventArgs e)
        {
            _currentImageId++;

            LoadImage();
        }
    }
}
