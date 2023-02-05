using Street;
using Street.Models;
using Street.Services;
using StreetMaui.Views;

namespace StreetMaui
{
    public partial class AppShell : Shell
    {
        IGroupStore GroupStore => DependencyService.Get<IGroupStore>();
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MapView), typeof(MapView));
            Routing.RegisterRoute(nameof(AddGroupPage), typeof(AddGroupPage));
            Routing.RegisterRoute(nameof(FriendSelectorPage), typeof(FriendSelectorPage));
            Routing.RegisterRoute(nameof(AddSpotPage), typeof(AddSpotPage));

            Init();
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