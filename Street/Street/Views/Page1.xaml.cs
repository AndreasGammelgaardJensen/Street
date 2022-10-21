using Street.Events;
using Street.Models;
using Street.Views.Popups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Street.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        ItemEvents itemEvents;
        ItemEvents it2; 
        public Page1()
        {
            InitializeComponent();
            itemEvents = new ItemEvents();
            itemEvents.IncommingSpots += OnIncommingSpots;

            it2 = DataStore.GetItemEvent();

            it2.CurrentGroup += UpdateMap;


        }

        private void MyMap_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            //DisplayAlert("Coordinates", $"Lat: {e.Position.Latitude} Long: {e.Position.Longitude}", "OK");
            Pin p = new Pin();
            p.Label = "MSALKmdl";
            p.Position = e.Position;

            p.MarkerClicked += Map_PinClicked;

            MyMap.Pins.Add(p);
            Debug.WriteLine(MyMap.Pins.Count());
            Navigation.ShowPopup(new Add_StreetSpot());

        }

        void Map_PinClicked(object sender, PinClickedEventArgs e)
        {
            //Open Edit Spot
            DisplayAlert("Pinclicked", null, "OK");
            


        }

        private void OnGroupClicked(object sender, EventArgs args)
        {
            Navigation.ShowPopup(new ShowGroupsPopup(itemEvents));
        }

        private void Map_RemovePins()
        {
            IList<Pin> pins = new List<Pin>(MyMap.Pins);

            foreach(Pin p in pins)
            {
                MyMap.Pins.Remove(p);
            }
        }


        private void Map_AddPins(List<SpotDTO> spots)
        {
            spots.ForEach(x =>
            {
                Pin p = new Pin();
                p.Label = "MSALKmdl";

                Position pPosition = new Position(x.Latitude, x.Longitude);
                p.Position = pPosition;

                MyMap.Pins.Add(p);

            });   
        }

        private void OnIncommingSpots(Object sender, IncommingSpotsArgs e)
        {
            Map_RemovePins();
            Map_AddPins(e.Spots);
        }

        private void UpdateMap(Object sender, CurrentGroupArgs e)
        {
            Map_RemovePins();
            Map_AddPins(e.CurrentGroup?.Spots);
        }
    }
}