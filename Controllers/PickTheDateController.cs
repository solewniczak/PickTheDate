using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PickTheDate.Models;
using PickTheDate.Services;

namespace PickTheDate.Controllers
{
    public class PickTheDateController : Controller
    {
        private readonly IGroupItemService _groupItemService;
        
        public PickTheDateController(IGroupItemService groupItemService)
        {
            _groupItemService = groupItemService;
        }
        public async Task<IActionResult> Groups()
        {
            var groups = await _groupItemService.GetGroupItemsAsync();

            var model = new GroupViewModel()
            {
                Groups = groups
            };

            return View(model);
        }
        
        public IActionResult Index()
        {
            return new AcceptedResult();
        }
    }
}