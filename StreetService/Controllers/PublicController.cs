using CoreStreet.ModelDTO;
using CoreStreet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace StreetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : Controller
    {
        private readonly IGroupRepository _rep;

        public PublicController(ILogger<WeatherForecastController> logger, IGroupRepository rep)
        {
            _rep = rep;
        }

        [HttpGet(Name = "PublicGroups")]
        public ActionResult<GroupDTO> Get()
        {

            var groups = _rep.GetGroups();
            return Ok(groups.First());
        }
    }
}
