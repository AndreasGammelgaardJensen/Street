using StreetMaui.Views;

namespace StreetMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MapView), typeof(MapView));
        }
    }
}