using Street.Models;
using Street.Services;
using StreetMaui.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Street.ViewModels
{
    internal class GroupsViewModel : BaseViewModel
    {
        public IGroupStore GroupStore => DependencyService.Get<IGroupStore>();
        private GroupDTO _selectedItem;
        public ObservableCollection<GroupDTO> Groups { get; }
        public Command LoadGroupsCommand { get; }
        public Command<GroupDTO> ItemTapped { get; }

        public GroupsViewModel()
        {
            Groups = new ObservableCollection<GroupDTO>();
            //LoadGroupsCommand = new Command(async () => await ExecuteLoadGroupsCommand());
            ExecuteLoadGroupsCommand();

            ItemTapped = new Command<GroupDTO>(OnItemSelected);
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
            DataStore.SetSelectedGroup(item);
            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            await Shell.Current.GoToAsync($"{nameof(MapView)}");
            //Shell.Current.Navigation.PopAsync(true);

        }
    }
}
