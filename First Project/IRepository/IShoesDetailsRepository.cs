using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
   public interface IShoesDetailsRepository
    {
        Task<List<ShoesData>> GetShoesData();
        Task<List<ShoesAllData>> getShoesAllDAta();
        Task<Object> addShoesData(ShoesData shoesData);
    }
}
