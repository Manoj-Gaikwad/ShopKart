using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using System.Threading.Tasks;
using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace First_Project.Repository
{
    public class CustomerDataRepository : ICustomerDataRepository
    {
        private readonly DBConnection dBConnection;
        private readonly IConfiguration configuration;
        public CustomerDataRepository(DBConnection dBConnection, IConfiguration configuration)
        {
            this.dBConnection = dBConnection;
            this.configuration = configuration;
        }

        public async Task<Boolean> addCoustomerData(CustomerData customerData)
        {
            if (customerData != null)
            {
                CustomerData customerData1 = new CustomerData()
                {
                    FirstName = customerData.FirstName,
                    LastName = customerData.LastName,
                    DOB = customerData.DOB,
                    Email = customerData.Email,
                    Gender = customerData.Gender,
                    Address = customerData.Address,
                    Pincode = customerData.Pincode,
                    ContactNo = customerData.ContactNo,
                    Password = customerData.Password,
                    CPassword = customerData.CPassword
                };
                await dBConnection.AddAsync(customerData1);
                await dBConnection.SaveChangesAsync();

                //for email send to registered user

                var email1 = new MimeMessage();
                email1.From.Add(MailboxAddress.Parse("manoj.gaikwad@sumasoft.net"));
                email1.To.Add(MailboxAddress.Parse(customerData1.Email));
                email1.Body = new TextPart(TextFormat.Html) { Text = "Welcome" + " " + customerData1.FirstName + " " + customerData1.LastName + "<br>" + "Thanks For selecting ShopKart" };
                email1.Subject = "ShopKart.com";

                var smtp = new SmtpClient();
                smtp.Connect(configuration.GetValue<string>("SMTP:Host"), configuration.GetValue<int>("SMTP:Port"), MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(configuration.GetValue<string>("SMTP:UserName"), configuration.GetValue<string>("SMTP:Password"));
                smtp.Send(email1);
                smtp.Disconnect(true);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Gender>> GetGender()
        {
            return await dBConnection.gender.ToListAsync();
        }

       
    }
}
