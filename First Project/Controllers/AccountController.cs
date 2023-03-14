using First_Project.Data;
using First_Project.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository _iaccountRepository)
        {
            this._accountRepository = _iaccountRepository;
        }

        [HttpPost("SignUpUser")]

        public Task<IdentityResult>SignUpUser([FromBody]SignUp signUp)
        {
                var result =_accountRepository.SignUpAsync(signUp);
                return result;
        }

        [HttpPost("SignIn")]

        public Task<string> SignIn([FromBody] SignIn signIn)
        {
            var result = _accountRepository.SignIn(signIn);
            return result;
        }
    }
}
