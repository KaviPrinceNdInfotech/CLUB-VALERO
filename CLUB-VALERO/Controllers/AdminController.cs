using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLUB_VALERO_DB.ViewModel;
using CLUB_VALERO_DB.BL;
using CLUB_VALERO_DB.DbContext_DB;
using CLUB_VALERO_DB.Entities;
using CLUB_VALERO_DB.Utilities;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLUB_VALERO.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private DBContextClub obj = new DBContextClub();
        private AdminBLL Adbll = new AdminBLL();

        public ActionResult Login()
        {
            return RedirectToAction("Login","Account");
        }
        //[Authorize(Roles ="admin,mrd,user")]
        public ActionResult Index()
        {
            ViewBag.TotalMember = obj.Members.ToList().Count();
            ViewBag.Message = obj.messages.ToList().Count();
            ViewBag.report = obj.Members.ToList().Count();
            ViewBag.Booking = obj.bookings.ToList().Count();
            ViewBag.EmiUser = obj.Members.ToList().Count();
            ViewBag.AmcUser = obj.Members.ToList().Count();
            ViewBag.onlinepayment = obj.paymentorders.ToList().Count();
            return View();
        }
        [HttpGet]
        public  ActionResult Profile(int id)
        {
            try
            {
                var result = obj.Members.FirstOrDefault(x => x.Id == id);
                if(result !=null)
                {
                    return View(result);
                }
                return View();
            }
            catch
            {
                throw new Exception("Server error");
            }
        }

       
        public ActionResult ListRemark(int? id)
        {
            return View(obj.remarks.Where(x=>x.UserId==id).ToList());
        }
        public ActionResult DeleteRemark(int id)
        {
            try
            {
                var result = obj.remarks.FirstOrDefault(x => x.Id == id);
                if(result!=null)
                {
                    obj.remarks.Remove(result);
                    obj.SaveChanges();
                }
                return RedirectToAction("ListMember");
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }

        public ActionResult AddRemark(int? id)
        {
            Session["id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddRemark(RemarkModel model)
        {
            try
            {              
                model.UserId = Convert.ToInt32(Session["id"]);
                bool isvalid = Adbll.AddRemark(model);
                if(isvalid)
                {
                    TempData["Remark Add"] = "Remark Add SuccessFully";
                    return RedirectToAction("ListMember");
                }
                else
                {
                    TempData["Remark Add"] = "Remark Add Not SuccessFully";
                    return RedirectToAction("ListMember");
                }
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }

        public ActionResult EditRemark(int id)
        {
            var result = obj.remarks.FirstOrDefault(x => x.Id == id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditRemark(Remark model)
        {
            try
            {
                bool isvalid = Adbll.EditRemark(model);
                if(isvalid)
                {
                    TempData["Remark Add"] = "Remark Update SuccessFully";
                    return RedirectToAction("ListMember");
                }
                else
                {
                    TempData["Remark Add"] = "Remark Update Not SuccessFully";
                    return RedirectToAction("ListMember");
                }
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }
        #region --Member Part--
        [Authorize(Roles ="admin")]
        public ActionResult RegisterMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterMember(Member model)
        {
            try
            {
            //    bool CheckMobile = obj.Members.Any(x => x.Mobile == model.Mobile);
            //    if(CheckMobile.Equals(false))
            //    {
                    Adbll.AddMember(model);                   
                    TempData["msg"] = "Member Registration SuccessFully";
                    ModelState.Clear();
                    return RedirectToAction("RegisterMember");
                
            }
            catch
            {
                throw new Exception("Somthing Erro");
            }
           
        }
       
        public ActionResult ListMember()
        {
            var result = obj.Members.ToList().OrderByDescending(x=>x.Id);
            return View(result);
        }


        public ActionResult Demo1()
        {
            return View(obj.Members.ToList());
        }

        [Authorize(Roles ="admin")]
        public ActionResult EditMember(int id)
        {
            var result = obj.Members.FirstOrDefault(x => x.Id == id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditMember(MemberViewModel model)
        {
            try
            {
                var result = obj.Members.FirstOrDefault(x => x.Id == model.Id);
                if(result !=null)
                {
                    Adbll.Updatemember(model);
                    TempData["msg"] = "Update Record SuccessFully";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    TempData["msg"] = "Update Record UnSuccessFully";
                    return View();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Somthing Went Wrong"+ex);
            }
          
        }
        
        public ActionResult DeleteMember(int id)
        {
            try
            {
                var result = obj.Members.FirstOrDefault(x => x.Id == id);
                if(result!=null)
                {
                    Adbll.DeleteMember(id);
                    TempData["msg"] = "Member Delete SuccessFully";
                    return RedirectToAction("ListMember");
                }
                else
                {
                    TempData["msg"] = "Member Delete Not SuccessFully";
                }
            }
            catch
            {
                throw new Exception("Something Went Wrong");
            }
            return View();
        }
        
        public ActionResult Forgatepassword(int id)
        {
            try
            {
                var result = obj.Members.FirstOrDefault(x => x.Id == id);
                if(result !=null)
                {
                    Adbll.ForGatePassWord(id);
                    TempData["Msg"] = "Forgate Password Success";
                    return RedirectToAction("ListMember");
                } 
            }
            catch
            {
                throw new Exception("Somthing Went Wrong");
            }
            return View();
        }
       
        public ActionResult WelcomeMail(int id)
        {
            try
            {
                var result = obj.Members.FirstOrDefault(x => x.Id == id);
                if(result !=null)
                {
                  bool isvalid=  Adbll.WelComeEmail(id);
                    if(isvalid)
                    {
                        TempData["msg"] = "WelComeEmail Send SuccessFully";
                    }
                    else
                    {
                        TempData["msg"] = "WelComeEmail Send Not SuccessFully";
                    }
                  
                    return RedirectToAction("ListMember");
                }
                else
                {
                    TempData["msg"] = "WelComeMail Not Send";
                }
            }
            catch
            {
                throw new Exception("Something Went Wrong");
            }
            return View();
        }
        
        public ActionResult PdfUpload(int id)
        {
            var result = obj.Members.FirstOrDefault(x => x.Id == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult PdfUpload(Member model)
        {
            try
            {
                Adbll.PdfUploadBL(model);
                TempData["msg"] = "Pdf Upload SuccessFully";
                return RedirectToAction("ListMember");
            }
            catch
            {
                throw new Exception("Something Went Wrong");
            }
        }

        public FileResult DownloadFile(int? fileId)
        {
            var file = obj.Members.ToList().Find(x => x.Id == fileId.Value);
            return File(file.Data, file.ContentType, file.FileName);

        }
        public ActionResult AmcAllUser()
        {
            return View(obj.Members.ToList());
        }
       
        public ActionResult DeleteAmcList(int id)
        {
            try
            {
                var result = obj.UserAmcs.FirstOrDefault(x => x.Id == id);
                if(result !=null)
                {
                    obj.UserAmcs.Remove(result);
                    obj.SaveChanges();
                }
                return RedirectToAction("AmPaymentList",new { id=result.UserId});
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }
       
        public ActionResult EmiRemainder(int id)
        {
            try
            {
                var result = obj.UserEmis.FirstOrDefault(x => x.Id == id);
                var reciver = obj.Members.FirstOrDefault(x => x.Id == result.UserId);
                if (result!=null)
                {
                    var emailsms = "Dear Member, We would like to remind you that Rs. '" + result.Amount + "' is due for EMI, year '" + result.EmiStartDate + "', kindly make the payment to avoid late charges. Please feel free to contact us for any query at info@clubvalero.com or 8448440705 Keep Holidaying!!!";

                    Emailmsg.SendEmail(reciver.Email, emailsms);
                }
                return RedirectToAction("EmiPaymentList");
            }
            catch
            {
                throw new Exception("Server Error");
            }
          
        }
        public ActionResult EmiAllUser()
        {
            return View(obj.Members.ToList());
        }
        public ActionResult EmiPaymentList(int id)
        {
            return View(obj.UserEmis.Where(x=>x.UserId==id).ToList());
        }
        public ActionResult EmiPaymentReport(int id)
        {
            var result = obj.Members.FirstOrDefault(x => x.Id == id);
            return View(result);
        }
        [HttpGet]
        public ActionResult UtilityPaymentUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UtilityPaymentUser(UtilityPaymentModel model)
        {
            try
            {
                int id = Convert.ToInt32(Session["Id"]);
                var result = obj.Members.FirstOrDefault(x => x.Id == id);
                PaymentOrder emp = new PaymentOrder()
                {
                    EmailId=result.Email,
                    Amount=model.Amount,
                    PaymentType="Utility",
                    UserId=result.MemberShipId,
                    Name=result.M_FirstName,
                    Mobileno=result.Mobile,
                    DateTime=DateTime.Now.ToString("dd/MM/yyyy")
                };
                obj.paymentorders.Add(emp);
                obj.SaveChanges();
                Session["PaymentMode"] = "Utility Payment";
                Session["Amount"] = model.Amount;
                Session["PaymentType"] = "Cash";
                ModelState.Clear();
                return RedirectToAction("EmiPaymentReport", new { id = result.Id });

            }
            catch
            {
                throw new Exception("Server Error");
            }
        }

        public ActionResult UserProfile(int id)
        {
            return View(obj.Members.FirstOrDefault(x=>x.Id==id));
        }
        public ActionResult Report()
        {
            return View(obj.Members.ToList());           
        }
        public ActionResult OnlinePaymentList()
        {
            return View(obj.paymentorders.ToList());
        }
        public ActionResult PaymentListUser(int id)
        {
            var result = obj.Members.FirstOrDefault(x => x.Id == id);
            return View(obj.paymentorders.Where(x=>x.UserId== result.MemberShipId).ToList());
        }
        public ActionResult UserRecipt(int id)
        {
            var result = obj.paymentorders.FirstOrDefault(x => x.Id == id);
            var data = obj.Members.FirstOrDefault(x => x.MemberShipId == result.UserId);
         ViewBag.city = data.City;
            ViewBag.state = data.State;
            ViewBag.pincode= data.PinCode;
            return View(result);
        }
       
        [HttpPost]
        public ActionResult UserAmcPayment(UserAmc model)
        {
            try
            {
                bool isvalid = Adbll.AmcPayment(model);
                if(isvalid)
                {
                    TempData["msg"] = "Amc Payment SuccessFully";
                    ModelState.Clear();
                    Session["PaymentMode"] = model.PaymentMode;
                    Session["PaymentType"] = "Amc Payment";
                    Session["Amount"] = model.Amount;
                    return RedirectToAction("EmiPaymentReport", new { id = model.UserId });
                }
                else
                {
                    TempData["msg"] = "Amc Payment Not SuccessFully";
                }
            }
            catch
            {
                throw new Exception("Server Error");
            }
            return View();
        }
        public ActionResult UserEmiPayment(int id)
        {
            var result = obj.UserEmis.FirstOrDefault(x => x.Id == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UserEmiPayment(UserEmi model)
        {
            try
            {
                bool isvalid = Adbll.EmiPayment(model);
                if(isvalid)
                {
                    TempData["msg"] = "Emi Payment SuccessFully";
                    ModelState.Clear();
                    Session["PaymentMode"] = model.PaymentMode;
                    Session["PaymentType"] = "Emi Payment";
                    Session["Amount"] = model.Amount;
                    return RedirectToAction("EmiPaymentReport",new { id= model.UserId});
                }
                else
                {
                    TempData["msg"] = "Emi Payment Not SuccessFully";
                    
                }
                return View();
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }

        public ActionResult IndianListCity()
        {
            return View(obj.IndianCities.ToList());
        }

        public ActionResult IndianListDelete(int id)
        {
            try
            {
                bool isvalid = Adbll.IndianListDelete(id);
                if(isvalid)
                {
                    TempData["msg"] = "Indian City Delete SuccessFully";
                  
                }
                else
                {
                    TempData["msg"] = "Indian City Delete Not SuccessFully";
                  
                }
                return RedirectToAction("IndianListCity");
            }
            catch
            {
                TempData["msg"] = "Server Error";
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddIndianCity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddIndianCity(IndianCity model)
        {
            try
            {
                bool isvalid = Adbll.AddCitiesName(model);
                if(isvalid)
                {
                    TempData["msg"] = "Indian City Add SuccessFully";
                    ModelState.Clear();
                    return View();

                }
                else
                {
                    TempData["msg"]= "Indian City Not Add SuccessFully";
                    return View();
                }
            }
            catch
            {
                TempData["msg"] = "Server Error";
                return View();
            }
        }
        #endregion --End Member--
   
      [HttpGet]
        public ActionResult AddIndianFullCity()
        {
            ViewBag.Indian = new SelectList(obj.IndianCities, "Id", "Name").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddIndianFullCity(IndianFullCityPageModel model)
        {
            try
            {
                ViewBag.Indian = new SelectList(obj.IndianCities, "Id", "Name").ToList();
                bool isvalid = Adbll.AddIndianFullCity(model);
                if(isvalid)
                {
                    TempData["msg"] = "Add City SuccessFully";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    TempData["msg"] = "Add City Not SuccessFully";
                }
               
            }
            catch
            {
                TempData["msg"] = "Server Error";
            }
            return View();
        }


        public ActionResult AsiaList()
        {
            return View(obj.Asianames);

        }
        [HttpGet]
        public ActionResult AddAsia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAsia(AsiaModel model)
        {
            try
            {
                bool isvalid = Adbll.AddAsia(model);
                if(isvalid)
                {
                    TempData["msg"] = "Asia Name Add SuccessFully";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    TempData["msg"] = "Asia Name Add Not SuccessFully";
                }
            }
            catch
            {
                TempData["msg"] = "Server Error";
            }
            return View();
        }

        public ActionResult AsiaDelete(int id)
        {
            try
            {
                bool isvalid = Adbll.DeleteAsia(id);
                if(isvalid)
                {
                    TempData["msg"] = "Delet SuccessFully";
                    return RedirectToAction("AsiaList");
                }
                else
                {
                    TempData["msg"] = "Delete Not SuccessFully";
                }
             
            }
            catch
            {
                TempData["msg"] = "Server Error";
            }
            return View();
        }
       
        public ActionResult BookMember()
        {
            return View(obj.Members.ToList());
        }

        public ActionResult BookingList(int? id)
        {
            if(id>0)
            {
                var result = obj.bookings.Where(x => x.UserId == id).ToList();
                return View(result);
            }
            else
            {
                return View(obj.bookings.ToList());
            }          
          
        }
       
      

        public ActionResult BookingDelete(int id)
        {
            try
            {
                var result = obj.bookings.FirstOrDefault(x => x.Id == id);
                if(result !=null)
                {
                    obj.bookings.Remove(result);
                    obj.SaveChanges();
                }
                return RedirectToAction("BookingList");
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }
        public ActionResult EditHotelBooking(int id)
        {
            ViewBag.MemberShipId = new SelectList(obj.Members, "Id", "MemberShipId");
            var result = obj.bookings.FirstOrDefault(x => x.Id == id);
            return View(result);
        }
        

        public ActionResult ContactusMessage()
        {
            return View(obj.contacts.ToList());
        }

        public ActionResult Message()
        {
            return View(obj.messages.ToList());
        }

        public JsonResult Getmembers(string term)
        {
            List<string> membersdata;
            membersdata = obj.Members.Where(x => x.MemberShipId.StartsWith(term)).Select(y => y.MemberShipId).ToList();

            return Json(membersdata, JsonRequestBehavior.AllowGet);
        }

     
        public ActionResult ReportToExcel()
        {
            var gv = new GridView();
            var query = obj.Members.Select(e => new
            {
                Id = e.Id,
                M_FirstName = e.M_FirstName,
                MemberShipId = e.MemberShipId,
                Mobile = e.Mobile,
                Email = e.Email,
                City = e.City,
                BalanceAmount = e.BalanceAmount,
                Tenure = e.Tenure,
                EmiAmount = e.EmiAmount,
                AmcCharge = e.AmcCharge
            }).ToList();
            gv.DataSource = query;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        public ActionResult BookingToExcel()
        {
            var gv = new GridView();
            var query = obj.Members.Select(e => new
            {
                Id = e.Id,
                M_FirstName = e.M_FirstName,
                MemberShipId = e.MemberShipId,
                Mobile = e.Mobile,
                Email = e.Email,
                City = e.City,
                BalanceAmount = e.BalanceAmount,
                Tenure = e.Tenure,
                EmiAmount = e.EmiAmount,
                AmcCharge = e.AmcCharge
            }).ToList();
            gv.DataSource = query;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        public ActionResult MembersToExcel()
        {
            var gv = new GridView();
            var query = obj.Members.Select(e => new
            {
                Id = e.Id,
                M_FirstName = e.M_FirstName,
                MemberShipId = e.MemberShipId,
                Mobile = e.Mobile,
                Email = e.Email,
                City = e.City,                
                BalanceAmount = e.BalanceAmount,
                Tenure = e.Tenure,
                EmiAmount = e.EmiAmount,
                AmcCharge = e.AmcCharge,
                M_Gender=e.M_Gender,
                M_DateOfBirth=e.M_DateOfBirth,
                Age=e.Age,
                AnnualIncome= e.AnnualIncome,
                FoodPreference=e.FoodPreference,
                ApptType=e.ApptType,
                TenureDate=e.TenureDate,
                DownPayment=e.DownPayment,
                ModeOfPayment=e.ModeOfPayment,
                ParchagePrice=e.ParchagePrice
            }).ToList();
            gv.DataSource = query;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }
       
        public FileResult download()
        {
            string path = "prince_May_2022.pdf";
            string actualPath = Server.MapPath("~/LIB/images/" + path);
            return File(actualPath, "application/pdf", Server.UrlEncode(path));
        }

        public ActionResult CustomerSupport()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BookHoliDay()
        {
            return View();
        }
       


        
        
    }
}