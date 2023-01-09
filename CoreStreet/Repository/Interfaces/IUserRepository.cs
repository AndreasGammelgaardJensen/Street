using EFDataAcces.Models;

namespace CoreStreet.Repository
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
        public User GetUser();
        public void DeleteUser();
    }
}
