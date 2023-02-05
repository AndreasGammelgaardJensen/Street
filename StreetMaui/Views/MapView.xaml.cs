using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Street;
using Street.Events;
using Street.Models;
using StreetMaui.Views.Popups;

namespace StreetMaui.Views;

public partial class MapView : ContentPage
{
    ItemEvents it2;
    public MapView()
    {
        InitializeComponent();
        it2 = DataStore.GetItemEvent();
        it2.IncommingSpots += OnIncommingSpots;
        it2.CurrentGroup += UpdateMap;


    }

    private void MyMap_MapClicked(object sender, MapClickedEventArgs e)
    {
        //DisplayAlert("Coordinates", $"Lat: {e.Position.Latitude} Long: {e.Position.Longitude}", "OK");
        //Pin p = new Pin();
        //p.Label = "MSALKmdl";
        //p.Position = e.Position;

        //p.MarkerClicked += Map_PinClicked;

        //MyMap.Pins.Add(p);
        //Debug.WriteLine(MyMap.Pins.Count());
        //Navigation.ShowPopup(new Add_StreetSpot());

        Pin p = new Pin();
        p.Label = "MSALKmdl";
        p.Location = MyMap.VisibleRegion.Center;
        MyMap.Pins.Add(p);



    }


    void Map_PinClicked(object sender, PinClickedEventArgs e)
    {
        //Open Edit Spot
        DisplayAlert("Pinclicked", null, "OK");

    }

    private void OnGroupClicked(object sender, EventArgs args)
    {
        this.ShowPopup(new ShowGroupsPopup(it2));
    }

    private void Map_RemovePins()
    {
        IList<Pin> pins = new List<Pin>(MyMap.Pins);

        foreach (Pin p in pins)
        {
            MyMap.Pins.Remove(p);
        }

    }


    private void Map_AddPins(List<SpotDTO> spots)
    {
        if (spots != null && spots.Count > 0)
            spots.ForEach(x =>
            {
                Pin p = new Pin();
                p.Label = "MSALKmdl";

                Location pPosition = new Location(x.Latitude, x.Longitude);
                p.Location = pPosition;

                MyMap.Pins.Add(p);

            });
    }

    private void Map_ZoomSpotPosition()
    {
        if (MyMap.Pins.Count <= 0)
            return;
        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(MyMap.Pins.First().Location, Distance.BetweenPositions(MyMap.Pins.First().Location, MyMap.Pins[MyMap.Pins.Count - 1].Location)));
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
        Map_ZoomSpotPosition();
        selectedGroupName.Text = e.CurrentGroup?.Name;
    }
}