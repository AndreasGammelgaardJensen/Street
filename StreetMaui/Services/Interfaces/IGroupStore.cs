using Street.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Street.Services
{
    internal interface IGroupStore
    {
        Task<List<GroupDTO>> GetGroupsAsync();
        Task<GroupDTO> GetPublicGroupAsync();
        Task DeleteGroupAsync(Guid id);
        Task<bool> AddGroupAsync(GroupDTO groupDto);
    }
}
