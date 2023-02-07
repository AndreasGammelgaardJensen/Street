
using Microsoft.AspNetCore.Mvc;
using StreetService.ModelDTO;
using StreetService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StreetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotController : ControllerBase
    {
        private readonly ISpotRepository _spotRep;

        public SpotController(ISpotRepository spotRep)
        {
            _spotRep = spotRep;
        }

        // GET: api/<SpotController>
        [HttpGet]
        public async Task<IEnumerable<SpotDTO>> Get()
        {
            return await _spotRep.GetSpots();
        }

        // GET api/<SpotController>/5
        [HttpGet("{id}")]
        public async Task<SpotDTO> Get(Guid id)
        {
            return await _spotRep.GetSpot(id);
        }

        // POST api/<SpotController>
        [HttpPost]
        public void Post([FromBody] SpotDTO spot)
        {
            _spotRep.AddSpot(spot);
        }

        // PUT api/<SpotController>/5
        [HttpPut]
        public void Put([FromBody] SpotDTO value)
        {
            _spotRep.UpdateSpot(value);
        }

        // DELETE api/<SpotController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            
        }
    }
}
