using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PickTheDate.Models;
using PickTheDate.Services;

namespace PickTheDate.Controllers
{
    [Authorize]
    public class PickTheDate : Controller
    {
        private readonly IRecordService _recordService;
        private readonly IGroupService _groupService;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public PickTheDate(IRecordService recordService,
            IGroupService groupService,
            UserManager<ApplicationUser> userManager)
        {
            _recordService = recordService;
            _groupService = groupService;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var recordsByDate = await _recordService.GetRecordsGroupedByDateAsync();
            var currentUserGroup = await _groupService.GetUserGroupAsync(currentUser);
            
            var model = new RecordGroupedByDateViewModel()
            {
                RecordsByDate = recordsByDate,
                UserGroup = currentUserGroup
            };

            return View(model);
        }
        
       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> pick(Guid id)
        {
            if (id == Guid.Empty) return RedirectToAction("Index");
            
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var successful = await _recordService.PickTheDateAsync(id, currentUser);
            if (!successful)
            {
                return BadRequest("Could not pick the date.");
            }

            return RedirectToAction("Index");
        }
        
        
    }
}