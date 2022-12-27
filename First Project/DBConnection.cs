using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Data
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options) : base(options)
        {

        }
        public DbSet<EmployeeDetails> employeeDetails { get; set; }
        public DbSet<PersonsData> persons { get; set; }

        public DbSet<CompanyData> company { get; set; }

        public DbSet<DepartmentData> department { get; set; }
        public DbSet<Gender> gender { get; set; }
        public DbSet<ClothsData> cloths { get; set; }

        public DbSet<ClothsAllData> subclothimages { get; set; }
        // public DbSet<ProductsDetailsData> productsdetails { get; set; }
        public DbSet<CartData> cart { get; set; }
        public DbSet<CustomerData> customerdetails { get; set; }


    }
}
