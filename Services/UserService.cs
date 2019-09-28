using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PickTheDate.Models;

namespace PickTheDate.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<SelectListItem>> SelectList()
        {
            var users = await _userManager.Users.ToArrayAsync();

            var usersSelectList = new List<SelectListItem>();
            foreach (var user in users)
            {
                usersSelectList.Add(new SelectListItem {Value = user.Id, Text = user.Email});
            }

            return usersSelectList;
        }
    }
}