using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
    public interface ICustomerDataRepository
    {
        Task<Boolean> addCoustomerData(CustomerData customerData);
        Task<List<Gender>> GetGender();
    }
}
