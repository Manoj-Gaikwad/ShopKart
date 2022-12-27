using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace First_Project.Data
{
    public class ProductsDetailsData
    {
        [Key]
        public int pid { get; set; }
        public string ptype { get; set; }
        public string pname { get; set; }
        public int pprice { get; set; }
        public string pcolor { get; set; }
        public string pdes { get; set; }
        public string pimage { get; set; }
    }
}
