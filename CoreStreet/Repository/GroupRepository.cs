using AutoMapper;
using CoreStreet.ModelDTO;
using EFDataAcces.DataAccess;
using EFDataAcces.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CoreStreet.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly StreetContext _dbContext;
        private readonly IMapper _mapper;

        public GroupRepository(StreetContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public void Add(GroupDTO groupDto)
        {
            var newGroupEntity = _mapper.Map<Group>(groupDto);
            newGroupEntity.Id = Guid.NewGuid();

            _dbContext.Group.Add(newGroupEntity);

            _dbContext.SaveChanges();
        }

        public void DeleteGroup(Guid id)
        {
            throw new NotImplementedException();
        }

        public GroupDTO GetGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            //TODO: Extract user id from claim
            var groups = _dbContext.Group.Include(x=>x.Users).Include(s=>s.Spots).ToList();
            var GroupDTO = _mapper.Map<IEnumerable<GroupDTO>>(groups);
            return GroupDTO;
        }
    }
}
