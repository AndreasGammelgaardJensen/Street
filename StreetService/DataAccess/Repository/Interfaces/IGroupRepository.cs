
using StreetService.DataAccess.ModelDTO;

namespace StreetService.DataAccess.Repository
{
    public interface IGroupRepository
    {
        public GroupDTO GetGroup(int groupId);
        public List<GroupDTO> GetGroups();
        public void DeleteGroup(int id);
    }
}
