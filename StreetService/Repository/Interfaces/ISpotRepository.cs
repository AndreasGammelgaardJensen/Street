
using StreetService.ModelDTO;

namespace StreetService.Repository
{
    public interface ISpotRepository
    {
        Task<IEnumerable<SpotDTO>> GetSpots();
        Task<SpotDTO> GetSpot(Guid id);
        Task<Guid> AddSpot(SpotDTO spot);
        void UpdateSpot(SpotDTO spot);
    }
}
