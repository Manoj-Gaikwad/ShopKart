using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.Data;
using First_Project.IRepository;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SignInController : ControllerBase
    {
        private readonly ISignInRepositiory isignInRepositiory;
        public SignInController(ISignInRepositiory isignInRepositiory)
        {
            this.isignInRepositiory = isignInRepositiory;
        }

        [HttpGet("loginEmployee/{email}/{password}")]

        public async Task<Boolean> CheckValidEmployee(string email, string password)
        {
            return await isignInRepositiory.CheckValidEmployee(email, password);
        }

        [HttpGet("loginEmployee1/{email}/{password}")]
        public async Task<LoginResponse> CheckValidEmployeeOrNot(string email, string password)
        {
            return await isignInRepositiory.CheckValidEmployeeOrNot(email, password);
        }

    }
}
