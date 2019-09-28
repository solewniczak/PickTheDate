using System.Linq;

namespace PickTheDate.Models
{
    public class RecordViewModel
    {
        public IOrderedEnumerable<Record> Records { get; set; }
    }
}