using Newtonsoft.Json;
using Street.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Street.Services
{
    internal class WebAPIService : IGroupStore
    {

        private static readonly string WebAPIUrl = "http://10.0.2.2:5126/api/Groups";
        private Uri uriTest
        {
            get { return new Uri(WebAPIUrl);
            }

        }

        public async Task<List<GroupDTO>> GetGroupsAsync()
        {
            var client = new HttpClient();

            try
            {
                var response = await client.GetAsync(uriTest);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<List<GroupDTO>>(content);
                    return items;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<GroupDTO> GetPublicGroupAsync()
        {
            var client = new HttpClient();

            try
            {
                var response = await client.GetAsync("http://10.0.2.2:5126/api/Public");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var group = JsonConvert.DeserializeObject<GroupDTO>(content);
                    return group;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
