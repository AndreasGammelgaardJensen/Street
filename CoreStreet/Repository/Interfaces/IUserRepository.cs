using CoreStreet.ModelDTO;
using EFDataAcces.Models;

namespace CoreStreet.Repository
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
