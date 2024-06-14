using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace First_Project.Data
{
    public class UserPermissions
    {
        public int? Id { get; set; }
        public int? CId { get; set; }
        public string? Email { get; set; }
        public string? Pages { get; set; }
    }
}
