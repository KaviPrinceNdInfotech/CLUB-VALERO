using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Razorpay.Api;
using System.Web.Mvc;
using CLUB_VALERO_DB.Entities;
using CLUB_VALERO_DB.ViewModel;
using CLUB_VALERO_DB.BL;
using CLUB_VALERO_DB.DbContext_DB;
using CLUB_VALERO_DB.Utilities;
namespace CLUB_VALERO.Controllers
{
    public class PaymentController : Controller
    {
        private DBContextClub db = new DBContextClub();
        private AdminBLL bll = new AdminBLL();
        public ActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        public ActionResult CreateOrder(/*PaymentInitiateModel _requestData*/)
        {
            var name = (string)Session["CandidateName"];
            var email = (string)Session["Email"];
            var mobile = (string)Session["Mobileno"];
            int Amount =Convert.ToInt32(Session["AmcAmount"]);

            // Generate random receipt number for order
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_qkvWoVAUxLt3M4", "57CC5Xc70R5XKNb5JnDjmVqS");
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", Amount * 100);  // Amount will in paise
            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            options.Add("payment_capture", "0"); // 1 - automatic  , 0 - manual
                                                 //options.Add("notes", "-- You can put any notes here --");
            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();

            // Create order model for return on view
            OrderModel orderModel = new OrderModel
            {
                orderId = orderResponse.Attributes["id"],
                razorpayKey = "rzp_test_qkvWoVAUxLt3M4",
                amount = Amount * 100,
                currency = "INR",
                name = name,
                email = email,
                contactNumber = mobile             
            };

            // Return on PaymentPage with Order data
            return View("PaymentPage", orderModel);
        }

        public class OrderModel
        {
            public string orderId { get; set; }
            public string razorpayKey { get; set; }
            public int amount { get; set; }
            public string currency { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string contactNumber { get; set; }
            public string address { get; set; }
            public string description { get; set; }
        }


        [HttpPost]
        public ActionResult Complete()
        {
            // Payment data comes in url so we have to get it from url

            // This id is razorpay unique payment id which can be use to get the payment details from razorpay server
            string paymentId = Request.Params["rzp_paymentid"];

            // This is orderId
            string orderId = Request.Params["rzp_orderid"];

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_qkvWoVAUxLt3M4", "57CC5Xc70R5XKNb5JnDjmVqS");

            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

            // This code is for capture the payment 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];

            //// Check payment made successfully

            if (paymentCaptured.Attributes["status"] == "captured")
            {
                int Id = Convert.ToInt32(Session["PersonId"]);
                var resultamc = db.UserAmcs.FirstOrDefault(x => x.UserId == Id);
                var resultamc2 = db.Members.FirstOrDefault(x => x.Id == Id);

                var resultemi = db.UserEmis.FirstOrDefault(x => x.UserId == Id);
                var resultemi2 = db.Members.FirstOrDefault(x => x.Id == Id);

                if ((string)Session["PaymentType"] == "Amc Payment")
                {
                    bll.AmcPaymentOnline(Id);
                    string AmcEmail = "Thank you for making a payment of Rs. '"+resultamc.Amount+"' towards your Annual Maintenance Charges. This payment will be reflected in your Membership account within 2 working days. Your payment reference number is Online. For any details you may contact us on 7042697042 or write us on info@clubvalero.com Keep Holidaying!!!";
                    Emailmsg.SendEmail(resultamc2.Email, AmcEmail);
                    
                }
                if((string)Session["PaymentType"]== "Emi Payment")
                {
                    bll.EmiPaymentOnline(Id);
                    string smsEmi = "Thank you for making a payment of Rs. '"+resultemi.Amount+"' towards your Annual Maintenance Charges. This payment will be reflected in your Membership account within 2 working days. Your payment reference number is Online. For any details you may contact us on 7042697042 or write us on info@clubvalero.com Keep Holidaying!!!";
                    Emailmsg.SendEmail(resultemi2.Email, smsEmi);
                }

                PaymentOrder emp = new PaymentOrder()
                {
                    PaymentType = (string)Session["PaymentType"],
                    Amount = (string)Session["AmcAmount"],
                    EmailId = (string)Session["Email"],
                    Mobileno = (string)Session["Mobileno"],
                    Name=(string)Session["CandidateName"],
                    UserId=(string)Session["UserId"],
                    DateTime=DateTime.Now.ToString("dd/MM/yyyy"),
                    
                };
                db.paymentorders.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Failed");
            }
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Failed()
        {
            return View();
        }
    }
}