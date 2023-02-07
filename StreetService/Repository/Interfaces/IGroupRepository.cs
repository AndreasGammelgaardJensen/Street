

using StreetService.ModelDTO;

namespace StreetService.Repository
{
    public interface IGroupRepository
    {
        public GroupDTO GetGroup(Guid groupId);
        public IEnumerable<GroupDTO> GetGroups();
        public void DeleteGroup(Guid id);
        public void Add(GroupDTO groupDto);
    }
}
