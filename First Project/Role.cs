using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project
{
    public enum Role
    {
        Admin,
        User
    }
    public class RoleRequirement : IAuthorizationRequirement
    {
        public RoleRequirement(Role role)
        {
            Role = role;
        }

        public Role Role { get; }
    }
}
