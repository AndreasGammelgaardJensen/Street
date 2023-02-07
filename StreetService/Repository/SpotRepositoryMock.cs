using StreetService.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetService.Repository
{
    public class SpotRepositoryMock : ISpotRepository
    {
        public static List<SpotDTO> Spots= new List<SpotDTO>();
        public Task<Guid> AddSpot(SpotDTO spot)
        {
            spot.Id = Guid.NewGuid();
            Spots.Add(spot);
            return  Task.FromResult(spot.Id);
        }

        public Task<SpotDTO> GetSpot(Guid id)
        {
            var spot = Spots.Single(s => s.Id == id);
            return Task.FromResult(spot);
        }

        public Task<IEnumerable<SpotDTO>> GetSpots()
        {
            return Task.FromResult(Spots.AsEnumerable());
        }

        public void UpdateSpot(SpotDTO spot)
        {
            var s = Spots.Single(s => s.Id == spot.Id);
            Spots.Remove(s);
            Spots.Add(spot);
           
        }
    }
}
