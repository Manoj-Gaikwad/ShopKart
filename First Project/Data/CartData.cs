using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Data
{
    public class CartData
    {
        [Key]
        public int id { get; set; }
        public int pid { get; set; }
        public string ptype { get; set; }
        public string pname { get; set; }
        public string psize { get; set; }
        public string pcolor { get; set; }
        public int pquantity { get; set; }
        public int pprice { get; set; }
        public int newprice { get; set; }
        public string pimage { get; set; }
        
    }
}
