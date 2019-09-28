using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickTheDate.Models
{
    public class Group
    {
        public string Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Leader { get; set; }
        
        [ForeignKey("Leader")]
        public ApplicationUser User { get; set; }
    }
}