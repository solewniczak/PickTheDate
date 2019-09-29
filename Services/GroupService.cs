using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PickTheDate.Data;
using PickTheDate.Models;
using Microsoft.EntityFrameworkCore;

namespace PickTheDate.Services
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Group[]> GetGroupsAsync()
        {
            return await _context.Groups
                .Include(g => g.User)
                .ToArrayAsync();
        }
        
        public async Task<Group> GetUserGroupAsync(ApplicationUser user)
        {
            var group = await _context.Groups
                .Where(x => x.Leader == user.Id)
                .SingleOrDefaultAsync();
            
            return group;
        }

        public async Task<bool> AddGroupAsync(Group newGroup)
        {
            var user = await _context.Users
                .Where(x => x.Id == newGroup.Leader)
                .SingleOrDefaultAsync();
            
            if (user == null) return false;
            
            _context.Groups.Add(newGroup);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}