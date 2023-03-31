using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Data
{
    public class ShoesData
    {
        [Key]
        public int pid { get; set; }
        public string ptype { get; set; }
        public string pname { get; set; }
        public int pprice { get; set; }
        public string pcolor { get; set; }
        public string pdes { get; set; }
        public int psize { get; set; }
        public int pquantity { get; set; }
        public string pimage { get; set; }
    }
}
