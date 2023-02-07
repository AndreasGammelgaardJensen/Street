
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreetService.ModelDTO;
using StreetService.Repository;

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
            var groups = _rep.GetGroups();
            return Ok(groups.ToList());
        }

        [HttpPost]
        public IActionResult Add([FromBody] GroupDTO groupModel)
        {
            _rep.Add(groupModel);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _rep.DeleteGroup(id);

            return Ok();
        }

    }
}
