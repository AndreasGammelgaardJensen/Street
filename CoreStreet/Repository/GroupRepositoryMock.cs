using CoreStreet.ModelDTO;

namespace CoreStreet.Repository
{
    public class GroupRepositoryMock : IGroupRepository
    {
        public static List<GroupDTO> groups = new List<GroupDTO>();
        private SeedData _seed;


        public GroupRepositoryMock(SeedData seed)
        {
            groups = seed.Groups;
            _seed = seed;
        }

        public void Add(GroupDTO group)
        {
            group.Id = System.Guid.NewGuid();
            groups.Add(group);
        }

        public void DeleteGroup(Guid id)
        {
            var groupToRemove = groups.Where(x => x.Id == id).SingleOrDefault();

            if(groupToRemove != null)
                groups.Remove(groupToRemove);
        }

        public GroupDTO? GetGroup(Guid groupId)
        {

            var group = groups.Find(x => x.Id == groupId);
            return group;
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            return groups;
        }
    }
}
