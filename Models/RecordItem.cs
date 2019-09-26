using System;
using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace PickTheDate.Models
{
    public class RecordItem
    {
        public Guid Id { get; set; }
        
        [Required]
        public LocalDate date { get; set; }

        [Required]
        public LocalTime startTime { get; set; }
        
        [Required]
        public LocalTime finishTime { get; set; }
        
        [Required]
        public string groupId { get; set; }
    }
}