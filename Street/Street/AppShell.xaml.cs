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
            Routing.RegisterRoute(nameof(MapView), typeof(MapView));
            Routing.RegisterRoute(nameof(AddGroupPage), typeof(AddGroupPage));
            Routing.RegisterRoute(nameof(FriendSelectorPage), typeof(FriendSelectorPage));
            Routing.RegisterRoute(nameof(AddSpotPage), typeof(AddSpotPage));

            Init();
            
            

    }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MapView");
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
