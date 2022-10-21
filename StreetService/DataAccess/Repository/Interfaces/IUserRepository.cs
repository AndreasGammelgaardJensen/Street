using EFDataAcces.Models;

namespace StreetService.DataAccess.Repository
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
        public User GetUser();
        public void DeleteUser();
    }
}
