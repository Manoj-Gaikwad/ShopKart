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
using System.Data.Common;

namespace First_Project.Repository
{
    public class SignInRepository : ISignInRepositiory
    {
        private readonly DBConnection dBConnection;
        private readonly IConfiguration configuration;
        public SignInRepository(DBConnection dBConnection, IConfiguration configuration)
        {
            this.dBConnection = dBConnection;
            this.configuration = configuration;

        }

        public async Task<Boolean> CheckValidEmployee(string email, string password)
        {
            var data = await dBConnection.employeeDetails.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
            if (data != null)
            {

                return true;
            }
            else
            {
                return false;
            }

        }
    

    public async Task<LoginResponse> CheckValidEmployeeOrNot(string email, string password)
    {
        LoginResponse loginResponse = new LoginResponse();
        var data = await dBConnection.employeeDetails.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
        

            return new LoginResponse
            {
                AuthToken = null,
                RefreshToken = this.GenerateRefreshTokenAsync()
            };
        
    } 

    public string GenerateRefreshTokenAsync()
        {
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();
            string randomChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!_-";

            for (int i = chars.Count; i < 20; i++)
            {
                char c = randomChars[rand.Next(0, randomChars.Length)];
                chars.Add(c);
            }
            String refreshToken = new string(chars.ToArray());
            return refreshToken;
        }
    }
}
