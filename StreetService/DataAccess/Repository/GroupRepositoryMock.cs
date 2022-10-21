using EFDataAcces.DataAccess;
using StreetService.DataAccess;
using StreetService.DataAccess.ModelDTO;
using StreetService.DataAccess.Repository;

namespace StreetRepository
{
    public class GroupRepositoryMock : IGroupRepository
    {

        private readonly StreetContext _dbContext;

        public GroupRepositoryMock(StreetContext context)
        {
            _dbContext = context;
        }

        public void DeleteGroup(int id)
        {
            throw new NotImplementedException();
        }

        public GroupDTO? GetGroup(int groupId)
        {
            GroupDTO? group = null;
            //if (_dbContext.Group.Count() == 0)
            //{
                var groups = SeedData.RunSeedData();

                group = groups.Find(x => x.Id == groupId);

                
            //}
            return group;
        }

        public List<GroupDTO> GetGroups()
        {
            GroupDTO? group = null;
            //if (_dbContext.Group.Count() == 0)
            //{
                return SeedData.RunSeedData();
            //}
        }
    }
}