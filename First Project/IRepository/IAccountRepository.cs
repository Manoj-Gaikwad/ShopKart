using First_Project.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
    public interface IAccountRepository
    {
        Task<Boolean> SignUpAsync(SignUp signUp);
       Task<object> SignIn(SignIn signIn);
    }
}
