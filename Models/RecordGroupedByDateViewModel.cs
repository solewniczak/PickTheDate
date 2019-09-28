using System;
using System.Linq;

namespace PickTheDate.Models
{
    public class RecordGroupedByDateViewModel
    {
        public IOrderedEnumerable<IGrouping<DateTimeOffset, Record>> RecordsByDate { get; set; }
        public Group UserGroup { get; set; }
    }
}