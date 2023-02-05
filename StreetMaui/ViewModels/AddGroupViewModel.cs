using Newtonsoft.Json;
using Street.Models;
using Street.Services;
using Street.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Street.ViewModels
{
    public class AddGroupViewModel : BaseViewModel
    {
        IUserStore UserStore => DependencyService.Get<IUserStore>();
        IGroupStore GroupStore => DependencyService.Get<IGroupStore>();
        ISpotStore SpotStore => DependencyService.Get<ISpotStore>();
        private int USER_ID = 1;

        public ObservableCollection<UserDTO> friendsList = new ObservableCollection<UserDTO>();
        public ObservableCollection<SpotDTO> spotList = new ObservableCollection<SpotDTO>();
        private string groupName;
        private bool isPublic;
        private List<UserDTO> _selectedFriends;
        public ICommand goToFriendListCommand { private set; get; }
        public ICommand handle_AddGroupClicked { private set; get; }

        public string GroupName
        {
            get => groupName;
            set => SetProperty(ref groupName, value);
        }

        public bool IsPublic
        {
            get => isPublic;
            set => SetProperty(ref isPublic, value);
        }

        public ObservableCollection<UserDTO> FriendList 
        {
            get => friendsList;
            set => SetProperty(ref friendsList, value);
        }

        public AddGroupViewModel()
        {
            goToFriendListCommand = new Command(
                execute: async () =>
                {
                    var groupState = GetFormState();
                    Preferences.Set("AddGroupState", JsonConvert.SerializeObject(groupState));
                    await Shell.Current.GoToAsync($"//Views/FriendSelectorPage?Id={USER_ID}");
                }
            );

            handle_AddGroupClicked = new Command(
                execute: async () =>
                {
                    GroupDTO groupDTO = GetFormState();
                    groupDTO.Created = DateTime.Now;
                    groupDTO.Id = System.Guid.NewGuid();
                    groupDTO.Spots = new List<SpotDTO>();

                    var result = await GroupStore.AddGroupAsync(groupDTO);

                    if(result)
                        await Shell.Current.GoToAsync($"//MapView");
             });

            if (Preferences.ContainsKey("SelectedFriends"))
            {
                var jsonStr = Preferences.Get("SelectedFriends", "");
                var addFrindesList = JsonConvert.DeserializeObject<List<UserDTO>>(jsonStr);
                _selectedFriends = addFrindesList != null?  addFrindesList : new List<UserDTO>();
                Preferences.Remove("SelectedFriends");

                foreach(var users in _selectedFriends)
                {
                    FriendList.Add(users);
                }
            }
            
            if(Preferences.ContainsKey("AddGroupState"))
            {
                var jsonStr = Preferences.Get("AddGroupState", "");
                var addGroupState = JsonConvert.DeserializeObject<GroupDTO>(jsonStr);
                GroupName = addGroupState.Name;
                IsPublic = addGroupState.IsPublic;
                Preferences.Remove("AddGroupState");
            }


        }

        private GroupDTO GetFormState()
        {
            var groupDTOState = new GroupDTO()
            {
                Name = GroupName,
                Users = _selectedFriends,
                IsPublic = IsPublic,

            };
            return groupDTOState;
        } 


        private async void PopulateSpots()
        {
           var spots = await SpotStore.GetSpotsAsync();

            foreach (var spot in spots)
            {
                spotList.Add(spot);
            }
        }

    }

   
}
