using Street.Events;
using Street.Services;
using Street.Services.Interfaces;
using Street.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Street
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
            Debug.WriteLine("Done ShellInit");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
