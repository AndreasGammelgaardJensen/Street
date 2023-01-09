using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Street.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSpotPage : ContentPage
    {
        public AddSpotPage()
        {
            InitializeComponent();
        }


        private async void AddTheCentreMarker()
        {
            try
            {

                Image _imgMarker = new Image();  //marker holder declaration
                int int_markerSize; //marker sizer 
                _imgMarker.Source = Device.OnPlatform(
                    iOS: ImageSource.FromUri(new Uri("http://www.launchappy.com/images/Marker.png")),
                    Android: ImageSource.FromFile("Marker.png"),
                    WinPhone: ImageSource.FromFile("Marker.png"));
                _imgMarker.VerticalOptions = LayoutOptions.CenterAndExpand;
                int_markerSize = 20;
                _imgMarker.WidthRequest = int_markerSize;
                _imgMarker.HeightRequest = int_markerSize;

                //mycentremarker_layout.Children.Add(_imgMarker);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}