using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
    public interface ICartDataRepository
    {
        Task<List<CartData>> getAllCartData(int id);
        Task<Boolean> addCartData(CartData cartData);
        Task<Boolean> removeItem(int id);
        Task<Boolean> updateCartData(CartData cartData);
    }
}
