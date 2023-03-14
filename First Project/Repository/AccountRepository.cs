using First_Project.Data;
using First_Project.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;




namespace First_Project.Repository
{
    public class AccountRepository: IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser>_signInManager;
        private readonly IConfiguration _iconfiguration;

        public AccountRepository(
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IConfiguration iconfiguration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._iconfiguration = iconfiguration;
        }

        public async Task<IdentityResult> SignUpAsync(SignUp signUp)
        {
            var User = new ApplicationUser()
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                DOB = signUp.DOB,
                Email = signUp.Email,
                Gender = signUp.Gender,
                Address = signUp.Address,
                Pincode = signUp.Pincode,
                ContactNo = signUp.ContactNo,
                UserName = signUp.Email,
                Password=signUp.Password,
                CPassword=signUp.CPassword
            };
          return  await _userManager.CreateAsync(User, signUp.Password);
        }

        public async Task<string>SignIn(SignIn signIn)
        {
            var result = await _signInManager.PasswordSignInAsync(signIn.Email, signIn.Password,false,false);

            if(!result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,signIn.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
        var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_iconfiguration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _iconfiguration["Jwt:Issure"],
                audience: _iconfiguration["Jwt:Audience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                ) ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
