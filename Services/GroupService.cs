using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return await _context.Groups.ToArrayAsync();
        }

        public async Task<bool> AddGroupAsync(Group newGroup)
        {
            _context.Groups.Add(newGroup);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}