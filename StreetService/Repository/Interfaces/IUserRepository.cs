
using StreetService.ModelDTO;
using StreetService.Models;

namespace StreetService.Repository
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
        public User GetUser();
        public void DeleteUser();
        public bool IsUserUnique(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
