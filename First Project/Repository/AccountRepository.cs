using First_Project.Data;
using First_Project.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class AccountRepository : IAccountRepository
    {
        private readonly DBConnection dBConnection;
        private readonly IConfiguration _iconfiguration;

        public AccountRepository(DBConnection dBConnection, IConfiguration _iconfiguration)
        {
            this.dBConnection = dBConnection;
            this._iconfiguration = _iconfiguration;
        }


        public async Task<Boolean> SignUpAsync(SignUp signUp)
        {
            var Role = "user";
            var User = new Users()
            {
                CId = null,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                DOB = signUp.DOB,
                Email = signUp.Email,
                Gender = signUp.Gender,
                Address = signUp.Address,
                Pincode = signUp.Pincode,
                ContactNo = signUp.ContactNo,
                Password = signUp.Password,
                CPassword = signUp.CPassword,
                Role = Role
            };
            await dBConnection.AddAsync(User);
            await dBConnection.SaveChangesAsync();
            return true;
        }
        [AllowAnonymous]
        public  async Task<object> SignIn(SignIn signIn)
        {

            var user = Authenticate(signIn);

                var token = Generate(user);
            Response r1 = new Response();
            r1.Output = user;
            r1.message = "Success";
            return r1;
            
        }
        [AllowAnonymous]
        private string Generate(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                _iconfiguration["Jwt:Issuer"],
                _iconfiguration["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        private Users Authenticate(SignIn signIn)
        {
            var currentUser = dBConnection.users.FirstOrDefault(o => o.Email.ToLower() == signIn.Email.ToLower() && o.Password == signIn.Password);

            return currentUser;
        }
    }
}
