using System;
using System.ComponentModel.DataAnnotations;

namespace PickTheDate.Models
{
    public class Group
    {
        public string Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Leader { get; set; }
    }
}