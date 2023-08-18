using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Data
{
    public class OrderData
    {
        public string? id { get; set; }
        public string? entity { get; set; }
        public int? amount { get; set; }
        public int? amount_paid { get; set; }
        public int? amount_due { get; set; }
        public string? currency { get; set; }
        public string? receipt { get; set; }
        public string? offer_id { get; set; }
        public string? status { get; set; }
        public int? attempts { get; set; }
        public string? created_at { get; set; }
    }
}
