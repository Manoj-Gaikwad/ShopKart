using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Repository
{
   
    public class ShoesDetailsRepository: IShoesDetailsRepository
    {
        private readonly DBConnection _dBConnection;
        public ShoesDetailsRepository(DBConnection dBConnection)
        {
            this._dBConnection = dBConnection;
        }
        public async Task<List<ShoesData>> GetShoesData()
        {
            return await _dBConnection.shoes.OrderByDescending(x => x.pid).ToListAsync();
        }

        public async Task<Object> addShoesData(ShoesData shoesData)
        {
            ShoesData d1 = new ShoesData()
            {
                ptype = shoesData.ptype,
                pstype = shoesData.pstype,
                pname = shoesData.pname,
                pprice = shoesData.pprice,
                pcolor = shoesData.pcolor,
                pdes = shoesData.pdes,
                psize = shoesData.psize,
                pquantity = shoesData.pquantity,
                pimage = shoesData.pimage,
                scimage1 = shoesData.scimage1,
                scimage2 = shoesData.scimage2,
                scimage3 = shoesData.scimage3
            };
            await _dBConnection.AddAsync(d1);
            await _dBConnection.SaveChangesAsync();

            Response r1 = new Response()
            {
                message = "success"
            };
            return r1;
        }


        public async Task<List<ShoesAllData>>getShoesAllDAta()
        {
            var data = await (from shoes in _dBConnection.shoes
                       select new ShoesAllData()
                       {
                           pid = shoes.pid,
                           ptype = shoes.ptype,
                           pstype = shoes.pstype,
                           pname = shoes.pname,
                           pprice = shoes.pprice,
                           pcolor = shoes.pcolor,
                           pdes = shoes.pdes,
                           psize=shoes.psize,
                           pquantity=shoes.pquantity,
                           pimage = shoes.pimage,
                           scimage1 = shoes.scimage1,
                           scimage2 = shoes.scimage2,
                           scimage3 = shoes.scimage3
                       }).OrderByDescending(x=>x.pid).ToListAsync();
            return data;
        }
    }
}
