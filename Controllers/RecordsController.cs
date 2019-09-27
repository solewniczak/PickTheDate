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
    public class RecordsController : Controller
    {
        private readonly IRecordService _recordService;
        private readonly UserManager<IdentityUser> _userManager;
        
        public RecordsController(IRecordService recordService,
            UserManager<IdentityUser> userManager)
        {
            _recordService = recordService;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            
            var records = await _recordService.GetRecordsAsync();
            
            var model = new RecordViewModel()
            {
                Records = records
            };

            return View(model);
        }
        
        public async Task<IActionResult> Manage()
        {
            var records = await _recordService.GetRecordsAsync();

            var model = new RecordViewModel()
            {
                Records = records
            };

            return View(model);
        }
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRecord(Record newRecord)
        {
            if (!ModelState.IsValid) return RedirectToAction("Manage");

            var successful = await _recordService.AddRecordAsync(newRecord);
            if (!successful)
            {
                return BadRequest("Could not add group.");
            }

            return RedirectToAction("Manage");
        }
    }
}