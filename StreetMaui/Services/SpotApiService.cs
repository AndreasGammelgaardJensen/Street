using Newtonsoft.Json;
using Street.Models;
using Street.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Street.Services
{
    internal class SpotApiService: BaseWebApi, ISpotStore
    {
        private static readonly string _apiEndpoint = "Spot";

        public async Task AddSpotAsync(SpotDTO spotDTO)
        {
            var response = await PostAsync(_apiEndpoint, spotDTO);
        }

        public async Task DeleteSpotAsync(Guid id)
        {
            var response = await DeleteAsync(String.Format("{0}?={1}", _apiEndpoint, id.ToString()));
        }

        public async Task<SpotDTO> GetSpotAsync(Guid id)
        {
            var response = await GetAsync(String.Format("{0}?={1}", _apiEndpoint, id.ToString()));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<SpotDTO>(content);
                return item;
            }
            return null;
        }

        public async Task<IEnumerable<SpotDTO>> GetSpotsAsync()
        {
            var response = await GetAsync(_apiEndpoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<IEnumerable<SpotDTO>>(content);
                return items;
            }
            return new List<SpotDTO>();
        }

        public Task UpdateSpotAsync(SpotDTO spotDTO)
        {
            throw new NotImplementedException();
        }
    }
}
