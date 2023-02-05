using Street.Services.Interfaces;
using Street.Services;

namespace StreetMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<GroupAPIService>();
            DependencyService.Register<BaseWebApi>();
            DependencyService.Register<IUserStore, UserStore>();
            DependencyService.Register<ISpotStore, SpotApiService>();
            MainPage = new AppShell();
        }
    }
}