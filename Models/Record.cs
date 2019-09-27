using System;
using System.ComponentModel.DataAnnotations;

namespace PickTheDate.Models
{
    public class Record
    {
        public Guid Id { get; set; }
        
        [Required]
        public DateTimeOffset Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }
        
        [Required]
        public TimeSpan FinishTime { get; set; }
        
        public string GroupId { get; set; }
    }
}