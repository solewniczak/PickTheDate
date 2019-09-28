using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickTheDate.Models;

namespace PickTheDate.Services
{
    public interface IGroupService
    {
        Task<Group[]> GetGroupsAsync();

        Task<bool> AddGroupAsync(Group newGroup);
        
        Task<Group> GetUserGroupAsync(ApplicationUser user);
    }
}