using System;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IOrderedEnumerable<Record>> GetRecordsAsync()
        {
            var records = await _context.Records.ToArrayAsync();
            return from record in records
                orderby record.Date, record.StartTime
                select record;
        }
        
        public async Task<IOrderedEnumerable<IGrouping<DateTimeOffset, Record>>> GetRecordsGroupedByDateAsync()
        {
            var records = await _context.Records.ToArrayAsync();
            return from record in records
                orderby record.StartTime
                group record by record.Date
                into newRecord
                orderby newRecord.Key
                select newRecord;
        }

        public async Task<bool> AddRecordAsync(Record newRecord)
        {
            _context.Records.Add(newRecord);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        
        public async Task<bool> PickTheDateAsync(Guid id, ApplicationUser user)
        {
            var record = await _context.Records
                .Where(x => x.Id == id && x.GroupId == null)
                .SingleOrDefaultAsync();
            
            if (record == null) return false;
            
            var userGroup = await _context.Groups
                .Where(x => x.Leader == user.Id)
                .SingleOrDefaultAsync();
            
            if (userGroup == null) return false;
            
            //remove previous selection
            var prevRecord = await _context.Records
                .Where(x => x.GroupId == userGroup.Id && x.Date == record.Date)
                .SingleOrDefaultAsync();

            var saveCount = 1;
            if (prevRecord != null)
            {
                prevRecord.GroupId = null;
                saveCount += 1;
            }
            
            record.GroupId = userGroup.Id;
            
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == saveCount; // Two entities should have been updated
        }
    }
}