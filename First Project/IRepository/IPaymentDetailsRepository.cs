using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
    public interface IPaymentDetailsRepository
    {
        Task<List<OrderData>> CreateOrder(int order_amount, string currency = "INR");
        object CapturePayment(string paymentId, decimal amount);
        //public object CreatePayment(string order_id);
    }
}
