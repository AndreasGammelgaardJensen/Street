using Newtonsoft.Json;
using Street.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Street.Services
{
    internal class GroupAPIService: BaseWebApi, IGroupStore
    {

        private static readonly string _apiEndpoint = "Groups";

        public async Task<bool> AddGroupAsync(GroupDTO groupDto)
        {
            var response = await PostAsync(_apiEndpoint, groupDto);

            if (!response.IsSuccessStatusCode)
                return false;
            return true;
        }

        public async Task DeleteGroupAsync(Guid id)
        {
            var response = await DeleteAsync(String.Format("{0}?={1}",_apiEndpoint,id.ToString()));
        }

        public async Task<List<GroupDTO>> GetGroupsAsync()
        {            
            try
            {
                var response = await GetAsync(_apiEndpoint);

                 if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<List<GroupDTO>>(content);
                    return items;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public async Task<GroupDTO> GetPublicGroupAsync()
        {
            try
            {
                var response = await GetAsync("GroupsPublic");

               if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var group = JsonConvert.DeserializeObject<GroupDTO>(content);
                    return group;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }
    }
}
