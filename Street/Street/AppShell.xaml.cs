using Street.Events;
using Street.Models;
using Street.Services;
using Street.ViewModels;
using Street.Views;
using Street.Views.Popups;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Street
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        IGroupStore GroupStore => DependencyService.Get<IGroupStore>();
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));
            Routing.RegisterRoute(nameof(Page1), typeof(Page1));
            Routing.RegisterRoute(nameof(Groups), typeof(Groups));
            Init();
            
            

    }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Page1");
        }

        private async void Init()
        {
             DataStore.Init();
            var currentGroup = await GroupStore.GetPublicGroupAsync();
            var groupe = currentGroup == null ? new GroupDTO() : currentGroup;
            DataStore.SetSelectedGroup(currentGroup);
        }
    }
}
