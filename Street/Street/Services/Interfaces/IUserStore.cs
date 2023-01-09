using Street.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Street.Services.Interfaces
{
    internal interface IUserStore
    {
        Task<ObservableCollection<UserDTO>> GetFriends(int userId);
    }
}
