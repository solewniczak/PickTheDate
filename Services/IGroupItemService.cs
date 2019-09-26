using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickTheDate.Models;

namespace PickTheDate.Services
{
    public interface IGroupItemService
    {
        Task<GroupItem[]> GetGroupItemsAsync();
    }
}