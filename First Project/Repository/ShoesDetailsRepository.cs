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
            return await _dBConnection.shoes.ToListAsync();
        }

        public async Task<List<ShoesAllData>>getShoesAllDAta()
        {
            var data = await (from shoes in _dBConnection.shoes
                       join subShoes in _dBConnection.subshoesimages
                        on shoes.pid equals subShoes.pid
                       where shoes.pid == subShoes.pid
                       select new ShoesAllData()
                       {
                           pid = shoes.pid,
                           ptype = shoes.ptype,
                           pname = shoes.pname,
                           pprice = shoes.pprice,
                           pcolor = shoes.pcolor,
                           pdes = shoes.pdes,
                           pimage = shoes.pimage,
                           scimage1 = subShoes.scimage1,
                           scimage2 = subShoes.scimage2,
                           scimage3 = subShoes.scimage3
                       }).ToListAsync();
            return data;
        }
    }
}
