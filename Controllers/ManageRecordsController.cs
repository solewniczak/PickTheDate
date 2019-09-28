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
    [Authorize(Roles = "Administrator")]
    public class ManageRecordsController : Controller
    {
        private readonly IRecordService _recordService;

        public ManageRecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }
        public async Task<IActionResult> Index()
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
            if (!ModelState.IsValid) return RedirectToAction("Index");

            var successful = await _recordService.AddRecordAsync(newRecord);
            if (!successful)
            {
                return BadRequest("Could not add record.");
            }

            return RedirectToAction("Index");
        }
    }
}