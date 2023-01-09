using Newtonsoft.Json;
using Street.Models;
using Street.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Street.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendSelectorPage : ContentPage, IQueryAttributable
    {
        private int _id;
        private List<UserDTO> _selectedUsers { get; set; }
        public ObservableCollection<UserDTO> Items { get; set; }

        public FriendSelectorPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<UserDTO>
            {
                new UserDTO() { Username = "asdas", Email="asda@asdas.dk", PasswordHash= new byte[20], PasswordSalt = new byte[10] },
                new UserDTO() { Username = "dd", Email="asda@asdas.dk", PasswordHash= new byte[20], PasswordSalt = new byte[10] },
                new UserDTO() { Username = "asd", Email="asda@asdas.dk", PasswordHash= new byte[20], PasswordSalt = new byte[10] },
                new UserDTO() { Username = "asd", Email="asda@asdas.dk", PasswordHash= new byte[20], PasswordSalt = new byte[10] },
                new UserDTO() { Username = "sad", Email="asda@asdas.dk", PasswordHash= new byte[20], PasswordSalt = new byte[10] },
                new UserDTO() { Username = "fdsf", Email="asda@asdas.dk", PasswordHash= new byte[20], PasswordSalt = new byte[10] },
                new UserDTO() { Username = "fgh", Email="asda@asdas.dk", PasswordHash= new byte[20], PasswordSalt = new byte[10] },
                new UserDTO() { Username = "cvb", Email="asda@asdas.dk", PasswordHash= new byte[20], PasswordSalt = new byte[10] },
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            string id = HttpUtility.UrlDecode(query["Id"]);
            _id = int.Parse(id);
        }

        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedUsers = new List<UserDTO>();

            foreach(UserDTO user in e.CurrentSelection)
            {
                _selectedUsers.Add(user);
            }

        }

        async void Handle_SelectButtonClicked(object sender, EventArgs e)
        {
            if(_selectedUsers != null)
            {
                var jsonStr = JsonConvert.SerializeObject(_selectedUsers);
                Preferences.Set("SelectedFriends", jsonStr);
            }
            

            await Shell.Current.Navigation.PopAsync();
            await Shell.Current.GoToAsync(nameof(AddGroupPage));
        }
    }
}
