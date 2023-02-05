using Newtonsoft.Json;
using Street.Models;
using Street.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Street.Services
{
    internal class UserStore : BaseWebApi, IUserStore
    {
        private static readonly string _apiEndpoint = "Users";

        public async Task<ObservableCollection<UserDTO>> GetFriends(int userId)
        {
            var client = new HttpClient();

            try
            {
                var response = await GetAsync(_apiEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<List<UserDTO>>(content);
                    return new ObservableCollection<UserDTO>(items);
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
