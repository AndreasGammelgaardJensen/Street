using CoreStreet.ModelDTO;
using CoreStreet.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StreetService.Controllers
{
    [Route("api/GroupsPublic")]
    [ApiController]
    public class GroupsPublicController : ControllerBase
    {
        private readonly IGroupRepository _rep;

        public GroupsPublicController(IGroupRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public ActionResult<Task<GroupDTO>> Get()
        {
            var publicGroup = _rep.GetGroups().Where(g => g.IsPublic).FirstOrDefault();

            if(publicGroup == null)
            {
                return NotFound();
            }

            return Ok(publicGroup);
        } 

    }
}
