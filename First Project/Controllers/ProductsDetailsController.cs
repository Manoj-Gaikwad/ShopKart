using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Project.IRepository;
using First_Project.Data;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDetailsController : ControllerBase
    {
        private readonly IProductsDetailsRepository iproductsDetailsRepository;

        public ProductsDetailsController(IProductsDetailsRepository iproductsDetailsRepository)
        {
            this.iproductsDetailsRepository = iproductsDetailsRepository;
        }
        

        [HttpGet("getAllEmployeeDetails")]

        public async Task<List<ProductsDetailsData>> getAllProductDetails()
        {
            return await iproductsDetailsRepository.getProductDetails();
        }

    }
}
