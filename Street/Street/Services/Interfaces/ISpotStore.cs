using Street.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Street.Services.Interfaces
{
    internal interface ISpotStore
    {
        Task<IEnumerable<SpotDTO>> GetSpotsAsync();
        Task<SpotDTO> GetSpotAsync(Guid id);
        Task UpdateSpotAsync(SpotDTO spotDTO);
        Task DeleteSpotAsync(Guid id);
        Task AddSpotAsync(SpotDTO spotDTO);
    }
}
