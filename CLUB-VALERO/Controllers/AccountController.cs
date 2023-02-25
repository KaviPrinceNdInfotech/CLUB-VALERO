using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLUB_VALERO_DB.Entities;
using CLUB_VALERO_DB.DbContext_DB;
using CLUB_VALERO_DB.ViewModel;
using CLUB_VALERO_DB.BL;
using System.Web.Security;

namespace CLUB_VALERO.Controllers
{
   [AllowAnonymous]
    public class AccountController : Controller
    {

        private DBContextClub _context = new DBContextClub();      


        public ActionResult Demo()
        {
            return View();
        }

        #region --Login Part--
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                bool IsValid = _context.Logins.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                bool isUser = _context.Members.Any(x => x.MemberShipId == model.UserName && x.Password == model.Password);
                var result = _context.Members.FirstOrDefault(x => x.MemberShipId == model.UserName && x.Password == model.Password);
                if (isUser)
                {
                    Session["Id"] = result.Id;
                    Session["CandidateName"] = result.M_FirstName;
                    Session["Mobileno"] = result.Mobile;
                    Session["Email"] = result.Email;
                    Session["UserId"] = result.MemberShipId;
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Admin");
                }
                if (IsValid)
                {
                   
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["MSG"] = "UserName And Password Invalid";
                    return View();
                }
        }
            catch (Exception ex)
            {
                throw new Exception("Somthing Went Wrong" + ex.Message);
    }

}

        #endregion --End Login Part--


        #region --Logout--
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        #endregion --End Logout--


    }
}