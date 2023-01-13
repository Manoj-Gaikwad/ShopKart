using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace First_Project.Repository
{
    public class SignInRepository: ISignInRepositiory
    {
        private readonly DBConnection dBConnection;
        private readonly IConfiguration configuration;
        public SignInRepository(DBConnection dBConnection, IConfiguration configuration)
        {
            this.dBConnection = dBConnection;
            this.configuration = configuration;

        }

        public async Task<Boolean>CheckValidEmployee(string email, string password)
        {
            var data=await dBConnection.employeeDetails.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
            if(data!=null)
            {
                var email1 = new MimeMessage();
                email1.From.Add(MailboxAddress.Parse("manoj.gaikwad@sumasoft.net"));
                email1.To.Add(MailboxAddress.Parse(email));
                email1.Body = new TextPart(TextFormat.Html) { Text = "Welcome"+" "+data.FirstName +" "+data.LastName+"<br>"+"Thanks For selecting ShopKart" };
                email1.Subject ="ShopKart.com";

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
    }
}
