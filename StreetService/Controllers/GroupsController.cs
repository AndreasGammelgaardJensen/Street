using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreetService.DataAccess.ModelDTO;
using StreetService.DataAccess.Repository;

namespace StreetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {

        private readonly IGroupRepository _rep;

        public GroupsController(ILogger<WeatherForecastController> logger, IGroupRepository rep)
        {
            _rep = rep;
        }

        [HttpGet(Name = "Groups")]
        public IActionResult Get()
        {
            var group = _rep.GetGroup(1);

            var groups = _rep.GetGroups();
            return Ok(groups.ToList());
        }

    }
}
