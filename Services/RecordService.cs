using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickTheDate.Data;
using PickTheDate.Models;
using Microsoft.EntityFrameworkCore;

namespace PickTheDate.Services
{
    public class RecordService : IRecordService
    {
        private readonly ApplicationDbContext _context;

        public RecordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Record[]> GetRecordsAsync()
        {
            return await _context.Records.ToArrayAsync();
        }

        public async Task<bool> AddRecordAsync(Record newRecord)
        {
            _context.Records.Add(newRecord);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}