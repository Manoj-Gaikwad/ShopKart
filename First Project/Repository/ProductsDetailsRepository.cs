using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Repository
{
   
    public class ProductsDetailsRepository
    {
        private readonly DBConnection dBConnection;

        public ProductsDetailsRepository(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;
        }


       

    }
}
