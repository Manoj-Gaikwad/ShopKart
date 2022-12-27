using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Data
{
    public class EmployeeDetails
    {
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB{get;set;}
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string CPassword { get; set; }
    }
}
