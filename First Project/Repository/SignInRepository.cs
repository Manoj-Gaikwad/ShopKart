using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace First_Project.Repository
{
    public class SignInRepository: ISignInRepositiory
    {
        private readonly DBConnection dBConnection;

        public SignInRepository(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;

        }

        public async Task<Boolean>CheckValidEmployee(string email, string password)
        {
            var data=await dBConnection.employeeDetails.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
            if(data!=null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
