using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Data
{
    public class LoginResponse
    {
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
