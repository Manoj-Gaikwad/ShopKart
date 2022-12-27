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
    public class CartDataController : ControllerBase
    {
        private readonly ICartDataRepository icartDataRepository;


        public CartDataController(ICartDataRepository icartDataRepository)
        {
            this.icartDataRepository = icartDataRepository;
        }

        [HttpGet("getAllCartData")]

        public async Task<List<CartData>>getAllCartData()
        {
            return await icartDataRepository.getAllCartData();
        }
        [HttpPost("addCartData")]

        public async Task<Boolean>addCartData(CartData cartData)
        {
            return await icartDataRepository.addCartData(cartData);
        }


    }
}
