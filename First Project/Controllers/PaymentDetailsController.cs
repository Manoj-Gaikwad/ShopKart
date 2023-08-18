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
    public class PaymentDetailsController : ControllerBase
    {
        private readonly IPaymentDetailsRepository  ipaymentDetailsRepository;
        

        public PaymentDetailsController(IPaymentDetailsRepository ipaymentDetailsRepository)
        {
            this.ipaymentDetailsRepository = ipaymentDetailsRepository;
        }

        [HttpPost("CreateOreder/{amount}")]
        public object CreateOrder(int amount)
        {
            var order = ipaymentDetailsRepository.CreateOrder(amount);

            // Return order details to the client
            return Ok(order);
        }
        [HttpPost("CaotyrePayment")]
        public object CapturePayment(string paymentId, decimal amount)
        {
            var payment = ipaymentDetailsRepository.CapturePayment(paymentId, amount);

            // Process the payment and return appropriate response
            if (payment != null && 1 == amount)
            {
                Response r1 = new Response();
                r1.message = "Payment captured successfully";
                // Payment captured successfully
                return r1;
            }
            else
            {
                // Payment capture failed
                Response r1 = new Response();
                r1.message = "Payment capture failed";
                // Payment captured successfully
                return r1;
            }
        }
        [HttpPost("CreatePayment")]
        public IActionResult CreatePayment(string order_id)
        {
            var payment = "https://example.com/payment?orderId=order_MArjqd1GkyrGdv";
            return Redirect(payment);
        }
    }
}
