using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PickTheDate.Models;

namespace PickTheDate.Services
{
    public interface IRecordService
    {
        Task<IOrderedEnumerable<Record>> GetRecordsAsync();

        Task<IOrderedEnumerable<IGrouping<DateTimeOffset, Record>>> GetRecordsGroupedByDateAsync();
        
        Task<bool> AddRecordAsync(Record newRecord);
        
        Task<bool> PickTheDateAsync(Guid id, ApplicationUser user);
    }
}