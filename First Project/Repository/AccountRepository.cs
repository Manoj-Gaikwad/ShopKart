using First_Project.Data;
using First_Project.IRepository;
//using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;




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
                Roles = Role
            };
            await dBConnection.AddAsync(User);
            await dBConnection.SaveChangesAsync();


            //Pages Permissions Assigning
           
                UserPermissions up = new UserPermissions();
                up.CId = User.CId;
                up.Email = User.Email;
                up.Pages = "Home,About,Contact";

                await dBConnection.AddAsync(up);
                await dBConnection.SaveChangesAsync();

            //send gmail message

            string fromEmail = _iconfiguration.GetValue<string>("SMTP:UserName");
            string fromPassword = _iconfiguration.GetValue<string>("SMTP:Password");

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.Subject = "Thanks For Joining Us!!";
            message.To.Add(new MailAddress(User.Email));
            message.Body = $"<html><body>Welcome {User.FirstName} {User.LastName},<br> Thanks For selecting ShopKart... <body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient(_iconfiguration.GetValue<string>("SMTP:Host"))
            {
                Port = _iconfiguration.GetValue<int>("SMTP:Port"),
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = _iconfiguration.GetValue<Boolean>("SMTP:EnableSsl")
            };
            smtpClient.Send(message);
            return true;
        }
        [AllowAnonymous]
        public async Task<object> SignIn(SignIn signIn)
        {
            var user = Authenticate(signIn);
            Response r1 = new Response();



            if (user == null)
            {
                r1.Output = "Error";
                r1.message = "User Not Found";
                return r1;
            }
            else
            {
               

                var token = Generate(user);
                if (token != null || token != "")
                {
                    var userPermission = UserPermissions(user.Email);
                    //for cheking token is made properly or not for particular user
                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(token);
                    var data = jwtSecurityToken;

                    r1.Output = user;
                    r1.message = "Success";
                    r1.Pages = userPermission.Pages;

                    return r1;
                }
                else
                {
                    r1.message = "Error";
                    return r1;
                }

               
            }
        }
        [AllowAnonymous]
        private string Generate(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            if(user!=null)
            {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Roles)
            };

            var token = new JwtSecurityToken(
              _iconfiguration["Jwt:Issuer"],
              _iconfiguration["Jwt:Audience"],
              claims:claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);
              return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return "Error";
            }
        }
        [AllowAnonymous]
        private Users Authenticate(SignIn signIn)
        {
            var currentUser = dBConnection.users.FirstOrDefault(o => o.Email.ToLower() == signIn.Email.ToLower() && o.Password == signIn.Password);

            return currentUser;
        }

        public UserPermissions UserPermissions(string Email)
        {
            UserPermissions userper = dBConnection.userpermissions.FirstOrDefault(x => x.Email==Email);
            return userper;
        }
    }
}
