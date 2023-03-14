using First_Project.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUp signUp);
        Task<string> SignIn(SignIn signIn);
    }
}
