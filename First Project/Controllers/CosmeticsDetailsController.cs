using First_Project.Data;
using First_Project.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosmeticsDetailsController : ControllerBase
    {

        private readonly ICosmeticsDetailsRepository icosmeticsDetailsRepositor;

        public CosmeticsDetailsController(ICosmeticsDetailsRepository icosmeticsDetailsRepositor)
        {
            this.icosmeticsDetailsRepositor = icosmeticsDetailsRepositor;
        }

        [HttpGet("GetCosmeticsData")]
        public async Task<List<CosmeticsData>> GetCosmeticsData()
        {
            return await icosmeticsDetailsRepositor.GetCosmeticsData();
        }
    }
}
