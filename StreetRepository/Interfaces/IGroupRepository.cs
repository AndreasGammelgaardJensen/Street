
namespace StreetService.DataAccess.Repository
{
    public interface IGroupRepository
    {
        public GroupDTO GetGroup(int groupId);
        public ICollection<GroupDTO> GetGroups(List<int> groupIds);
        public void DeleteGroup(int id);
    }
}
