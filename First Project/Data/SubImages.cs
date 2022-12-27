using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Data
{
    public class SubImages
    {
        [Key]
        public int pid { get; set; }
        public string scimage1 {get;set;}
        public string scimage2 { get; set; }
        public string scimage3 { get; set; }

    }
}
