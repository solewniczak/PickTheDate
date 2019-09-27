using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PickTheDate.Models;

namespace PickTheDate.Services
{
    public interface IRecordService
    {
        Task<Record[]> GetRecordsAsync();
        
        Task<bool> AddRecordAsync(Record newRecord);
    }
}