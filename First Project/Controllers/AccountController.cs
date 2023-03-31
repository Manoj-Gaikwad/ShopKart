using First_Project.Data;
using First_Project.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _iaccountRepository;
        private IConfiguration _config;
        private readonly DBConnection dBConnection;

        public AccountController(IAccountRepository _iaccountRepository, IConfiguration config, DBConnection dBConnection)
        {
            this._iaccountRepository = _iaccountRepository;
            _config = config;
            this.dBConnection = dBConnection;
        }

        [HttpPost("SignUpUser")]

        public Task<Boolean>SignUpUser([FromBody]SignUp signUp)
        {
                var result =_iaccountRepository.SignUpAsync(signUp);
                return result;
        }


        [AllowAnonymous]
        [HttpGet("SignIn")]
        public object SignIn([FromBody] SignIn signIn)
        {
             var result = _iaccountRepository.SignIn(signIn);
                return result;
        }
      

    }
}
