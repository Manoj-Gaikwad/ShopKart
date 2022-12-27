using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
    public interface ISignInRepositiory
    {
        Task<Boolean> CheckValidEmployee(string email, string password);
    }
}
