using Street.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Street.ViewModels
{
    internal class FriendSelectorPageViewModel : BaseViewModel
    {
        private int _id;
        public ICommand SelectedFriendChangedCommand { get; }
        public ObservableCollection<UserDTO> Items { get; set; }
        private List<UserDTO> _friends { get; set; }


        public FriendSelectorPageViewModel(int userId)
        {
            _id = userId;
            Items = new ObservableCollection<UserDTO>();
            SelectedFriendChangedCommand = new Command((sender) =>
            {
                

                UserDTO userDTO = sender as UserDTO;
                Console.WriteLine("Select item in Colletionview" + userDTO);

            });


            PopulateItems();
        }

        //public Command SelectedFriendChangedCommand
        //{
        //    get
        //    {
        //        return new Command((sender) => 
        //        {
        //            UserDTO userDTO  = sender as UserDTO;
        //            Console.WriteLine("Select item in Colletionview" + userDTO);
        //        });
        //    }
        //}

        private void PopulateItems()
        {
            var user1 = new UserDTO {  Username = "Donny" };
            var user2 = new UserDTO {  Username = "Barley" };
            Items.Add(user1);
            Items.Add(user2);
        }

        private void AddFriends(IEnumerable<UserDTO> selectedFriends)
        {
        }


        
    }
}
