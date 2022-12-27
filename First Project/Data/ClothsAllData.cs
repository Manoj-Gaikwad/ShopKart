using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace First_Project.Data
{
    public class ClothsAllData
    {
        [Key]
        public int pid { get; set; }
        public string ptype { get; set; }
        public string pname { get; set; }
        public int pprice { get; set; }
        public string pcolor { get; set; }
        public string pdes { get; set; }
        public string pimage { get; set; }
        public string scimage1 { get; set; }
        public string scimage2 { get; set; }
        public string scimage3 { get; set; }
    }
}
