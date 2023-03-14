using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using First_Project.IRepository;

namespace First_Project.Repository
{
    public class CosmeticsDetailsRepository: ICosmeticsDetailsRepository
    {
        private readonly DBConnection dbconnection;

        public CosmeticsDetailsRepository(DBConnection dbconnection)
        {
            this.dbconnection = dbconnection;
        }

        public async Task<List<CosmeticsData>>GetCosmeticsData()
        {
            return await dbconnection.cosmetic.ToListAsync();
        }
    }
}
