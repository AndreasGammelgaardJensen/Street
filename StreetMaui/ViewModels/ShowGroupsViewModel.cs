using CommunityToolkit.Maui.Views;
using Street.Events;
using Street.Models;
using Street.Services;
using StreetMaui.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Street.ViewModels
{
    internal class ShowGroupsViewModel : BaseViewModel
    {
        public IGroupStore GroupStore => DependencyService.Get<IGroupStore>();
        private GroupDTO _selectedItem;
        public ObservableCollection<GroupDTO> Groups { get; }
        public Command<GroupDTO> ItemTapped { get; }
        private ItemEvents _itemEvents;

        private Popup _popup;

        public ICommand AddGroupClicked { private set; get; }

        public ShowGroupsViewModel(ItemEvents itemEvents, Popup popup)
        {
            _popup = popup;
            _itemEvents = itemEvents;
            Groups = new ObservableCollection<GroupDTO>();
            //LoadGroupsCommand = new Command(async () => await ExecuteLoadGroupsCommand());
            ExecuteLoadGroupsCommand();

            ItemTapped = new Command<GroupDTO>(OnItemSelected);

            AddGroupClicked = new Command(
                execute: async () =>
                {
                    _popup.Close();
                    await Shell.Current.GoToAsync(nameof(AddGroupPage));
                });
        }





        async void ExecuteLoadGroupsCommand()
        {
            IsBusy = true;

            try
            {
                Groups.Clear();
                var items = await GroupStore.GetGroupsAsync();
                foreach (var item in items)
                {
                    Groups.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        async void OnItemSelected(GroupDTO item)
        {
            if (item == null)
                return;

            _itemEvents.OnCurrentGroup(new CurrentGroupArgs(item));
            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            await Shell.Current.GoToAsync("//MapView");

            if (_popup != null)
                _popup.Close();
        }
    }
}

