using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLUB_VALERO_DB.Entities;
using CLUB_VALERO_DB.DbContext_DB;
using CLUB_VALERO_DB.ViewModel;
using CLUB_VALERO_DB.BL;
namespace CLUB_VALERO.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private DBContextClub _context = new DBContextClub();

        private AdminBLL Addbll = new AdminBLL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Membership()
        {
            return View();
        }

        public ActionResult Destinations()
        {
            ViewBag.Indian = _context.IndianCities.ToList();
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetIndianCity(int Id)
        {
            var query = _context.indianFullCityPages.Where(x => x.IndianCityId == Id).FirstOrDefault();
            return View(query);
        }

        [HttpPost]
        public ActionResult AddContact(ContactUsModel model)
        {
            try
            {
                bool isvalid = Addbll.AddContactus(model);
                if (isvalid)
                {
                    ViewBag.success = "Message Submit SuccessFully";
                }
                else
                {
                    ViewBag.success = "Message Submit Not SuccessFully";
                }
                return RedirectToAction("Contact");
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }
        [HttpGet]
        public ActionResult Message()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Message(Message model)
        {
            try
            {
                bool isvalid = Addbll.AddMessage(model);
                if(isvalid)
                {
                    ViewBag.Message = "Message SuccessFully Send";
                }
                else
                {
                    ViewBag.Message = "Message SuccessFully Not Send";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }

    }
}