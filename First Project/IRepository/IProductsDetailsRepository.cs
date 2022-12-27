using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
    public interface IProductsDetailsRepository
    {
        Task<List<ProductsDetailsData>> getProductDetails();
    }
}
