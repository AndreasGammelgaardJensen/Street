using StreetService.DataAccess;
using StreetService.ModelDTO;
using StreetService.Models;
using StreetService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CoreStreet.Repository
{
    internal class SpotRepository : ISpotRepository
    {
        private readonly StreetContext _dbContext;

        public SpotRepository(StreetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Guid> AddSpot(SpotDTO spot)
        {
            
            
            Spot newSpot = new Spot();
            newSpot.Longitude = spot.Longitude;
            newSpot.Latitude = spot.Latitude;
            newSpot.Name = spot.Name;
            newSpot.Created = new DateTime();
            newSpot.Description = spot.Description;

            _dbContext.Spot.Add(newSpot);

            var userCreator = _dbContext.User.Single(c => c.Id == spot.Creator.Id);
            newSpot.Creator = userCreator;

            _dbContext.Spot.Add(newSpot);

            //Adding Existing Image Entities to SpotEntity
            var imageIds = spot.Images.Select(t => t.Id).ToList();
            var imageEntitys = _dbContext.Image.Where(c => imageIds.Contains(c.Id));

            foreach (var imageEntity in imageEntitys)
            {
                newSpot.Images.Add(imageEntity);
            }

            _dbContext.SaveChangesAsync();

            return Task.FromResult(newSpot.Id);




        }

        public Task<SpotDTO> GetSpot(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SpotDTO>> GetSpots()
        {
            throw new NotImplementedException();
        }

        public void UpdateSpot(SpotDTO spot)
        {
            throw new NotImplementedException();
        }

    }
}
