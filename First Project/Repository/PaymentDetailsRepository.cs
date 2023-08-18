using DocumentFormat.OpenXml.Office2010.Excel;
using First_Project.Data;
using First_Project.IRepository;
using Microsoft.Extensions.Configuration;
using Razorpay.Api;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace First_Project.Repository
{
    public class PaymentDetailsRepository:IPaymentDetailsRepository
    {
        private readonly string _key;
        private readonly string _secret;
        private readonly RazorpayClient _razorpayClient;
        public string PaymentLink1="";
        RazorpayClient client;



        public PaymentDetailsRepository(IConfiguration configuration)
        {
            _key = configuration.GetValue<string>("Razorpay:ApiKey");
            _secret = configuration.GetValue<string>("Razorpay:ApiSecret");
             this.client = new RazorpayClient(_key, _secret);
        }

        public async Task<List<OrderData>> CreateOrder(int order_amount, string currency = "INR")
        {
           
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", order_amount * 100); // amount in the smallest currency unit
            options.Add("receipt", "order_rcptid_11");
            options.Add("currency", currency);
            Order orderResponse = client.Order.Create(options);
            string PaymentLink = orderResponse["ShortUrl"];

            if (orderResponse != null)
            {
                string orderId = orderResponse["id"].ToString();

                var data = this.client.Order.Fetch(orderId);

                List<OrderData> list = new List<OrderData>();

                if (data != null)
                {
                    OrderData d1 = new OrderData()
                    {
                        id = data["id"]?.ToString(),
                        entity = data["entity"]?.ToString(),
                        amount = int.Parse(data["amount"]?.ToString()),
                        amount_paid = int.Parse(data["amount_paid"]?.ToString()),
                        amount_due = int.Parse(data["amount_due"]?.ToString()),
                        currency = data["currency"]?.ToString(),
                        receipt = data["receipt"]?.ToString(),
                        offer_id = data["offer_id"]?.ToString(),
                        status = data["status"]?.ToString(),
                        attempts = int.Parse(data["attempts"]?.ToString()),
                        created_at = data["created_at"]?.ToString()
                    };
                    list.Add(d1);
                    return list;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                // Handle the case where orderResponse is null (order creation failed)
                // You can log the error, throw an exception, or handle it as per your application's requirements.
                return null;
            }


            //d1 = client.Order.Fetch(order.id);



        }
        public object CapturePayment(string paymentId, decimal amount)
        {
            var payment = _razorpayClient.Payment.Fetch(paymentId);

            var captureOptions = new Dictionary<string, object>
        {
            { "amount", amount * 100 }, // Amount in smallest currency unit (e.g., paisa for INR)
        };

            return payment.Capture(captureOptions);
        }

        public object CreatePayment(string order_id)
        {
            var paymentOptions = new Dictionary<string, object>
            {
                { "amount", 100000 },                 // The payment amount in paise (e.g., 100000 paise = ₹1000)
                { "currency", "INR" },
                { "order_id", order_id},      // Replace "YOUR_ORDER_ID" with the actual order ID
                { "payment_capture", "1" },
                { "name", "Manoj Gaikwad"},      // Replace "YOUR_ORDER_ID" with the actual order ID
                { "email", "manojdgaikwad4165@gmail.com"},
                {"contact",8408054109}
                // Set to 1 to capture the payment immediately
                // Add more options as needed
            };
            var redirectUrl = $"https://api.razorpay.com/v1/payment/embedded/order=order_MArjqd1GkyrGdv";
            var payment ="https://example.com/payment?orderId=order_MArjqd1GkyrGdv";
            return payment;
        }
    }


}
