using System.Collections.Generic;
using PickTheDate.Models;

namespace PickTheDate.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Everyone { get; set;}
    }
}