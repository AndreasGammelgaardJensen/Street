
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using StreetService.ModelDTO;
using StreetService.Repository;

namespace StreetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginRequest)
        {
            var userResponse = await _userRepo.Login(loginRequest);
            if(userResponse.User == null || string.IsNullOrEmpty(userResponse.Token))
            {
                return BadRequest();
            }

            return userResponse;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] RegistrationRequestDTO regRequestDTO)
        {
            var isUserUnique = _userRepo.IsUserUnique(regRequestDTO.Username);

            if (!isUserUnique)
                return BadRequest();

            var registeredUser = await _userRepo.Register(regRequestDTO);
            if (registeredUser == null)
                return BadRequest();

            return registeredUser;
        }
    }
}
