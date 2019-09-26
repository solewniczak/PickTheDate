using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickTheDate.Models;

namespace PickTheDate.Services
{
    public class FakeGroupItemService : IGroupItemService
    {
        public Task<GroupItem[]> GetGroupItemsAsync()
        {
            var item1 = new GroupItem
            {
                Id = "wt_gr1",
                Name = "bomber"
            };
            var item2 = new GroupItem
            {
                Id = "wt_gr3",
                Name = "Muzziq"
            };

            return Task.FromResult(new[] {item1, item2});
        }
    }
}