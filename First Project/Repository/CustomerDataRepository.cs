using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.Data;
using First_Project.IRepository;

namespace First_Project.Repository
{
    public class CustomerDataRepository: ICustomerDataRepository
    {
        private readonly DBConnection dBConnection;

        public CustomerDataRepository(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;
        }

        public async Task<Boolean>addCoustomerData(CustomerData customerData)
        {
            if(customerData!=null)
            { 
            CustomerData customerData1 = new CustomerData()
            {
                FirstName=customerData.FirstName,
                LastName=customerData.LastName,
                DOB=customerData.DOB,
                Email=customerData.Email,
                Gender=customerData.Gender,
                Address=customerData.Address,
                Pincode=customerData.Pincode,
                ContactNo=customerData.ContactNo,
                Password=customerData.Password,
                CPassword=customerData.CPassword
            };
            await dBConnection.AddAsync(customerData1);
            await dBConnection.SaveChangesAsync();
            return true;
        }
            else
            {
                return false;
            }
            
        }
    }
}
