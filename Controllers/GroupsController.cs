using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PickTheDate.Models;
using PickTheDate.Services;

namespace PickTheDate.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;
        
        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        public async Task<IActionResult> Index()
        {
            var groups = await _groupService.GetGroupsAsync();

            var model = new GroupViewModel()
            {
                Groups = groups
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGroup(Group newGroup)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            var successful = await _groupService.AddGroupAsync(newGroup);
            if (!successful)
            {
                return BadRequest("Could not add group.");
            }

            return RedirectToAction("Index");
        }
    }
}