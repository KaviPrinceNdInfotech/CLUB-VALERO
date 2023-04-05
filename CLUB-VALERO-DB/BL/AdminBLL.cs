using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLUB_VALERO_DB.Entities;
using CLUB_VALERO_DB.ViewModel;
using CLUB_VALERO_DB.DbContext_DB;
using CLUB_VALERO_DB.Utilities;
using System.IO;

namespace CLUB_VALERO_DB.BL
{
   public class AdminBLL
    {
        private DBContextClub _context = new DBContextClub();
        private GenerateId Gid = new GenerateId();
        public void AddMember(Member model)
        {
            try
            {
              
                Member emp = new Member()
                {
                    
                    //MemberShipId = Gid.MemberShipId(),
                    MemberShipId=model.MemberShipId,
                    Password = Guid.NewGuid().ToString().Substring(0, 6),
                    M_FirstName = model.M_FirstName,
                    M_LastName = model.M_LastName,                  
                    M_Gender = model.M_Gender,
                    SpecialOffer=model.SpecialOffer,
                    M_DateOfBirth = model.M_DateOfBirth,
                    M_Salution = model.M_Salution,
                    Age = model.Age,
                    MaritalStatus = model.MaritalStatus,
                    Occupation = model.Occupation,
                    AnnualIncome = model.AnnualIncome,
                    FoodPreference = model.FoodPreference,
                    Co_Salution = model.Co_Salution,
                    Co_Gender = model.Co_Gender,
                    Co_FirstName = model.Co_FirstName,                  
                    Co_LastName = model.Co_LastName,
                    Co_Mobile = model.Co_Mobile,
                    Co_Email = model.Co_Email,
                    No_Co_Adults = model.No_Co_Adults,
                    No_Co_Children = model.No_Co_Children,
                    Co_Child1 = model.Co_Child1,
                    Co_Child1_DateOfBirth = model.Co_Child1_DateOfBirth,
                    Co_Child2 = model.Co_Child2,
                    Co_Child2_DateOfBirth = model.Co_Child2_DateOfBirth,
                    Co_Child3 = model.Co_Child3,
                    Co_Child3_DateOfBirth = model.Co_Child3_DateOfBirth,
                    NameOfPremission_Building = model.NameOfPremission_Building,
                    Road_Street_Lane = model.Road_Street_Lane,
                    Area_Locality = model.Area_Locality,
                    LandMark = model.LandMark,
                    State = model.State,
                    City = model.City,
                    Country = model.Country,
                    PinCode = model.PinCode,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    ApptType = model.ApptType,
                    Tenure = model.Tenure,
                    NoOf_Night_Year = model.NoOf_Night_Year,
                    Occupants = model.Occupants,
                    MemberShipType = model.MemberShipType,
                    AmcCharge = model.AmcCharge,
                    ClubValeroMemebr = model.ClubValeroMemebr,
                    MemberShipNo = model.MemberShipNo,
                    MemberShip_Price = model.MemberShip_Price,
                    AdminFee = model.AdminFee,
                    DownPayment = model.DownPayment,
                    BalanceAmount = model.BalanceAmount,
                   ManagerName=model.ManagerName,
                   ParchagePrice=model.ParchagePrice,
                    ModeOfPayment = model.ModeOfPayment,
                    CashDate = model.CashDate,
                    CashAmount = model.CashAmount,
                    CashReceiptNo = model.CashReceiptNo,
                    CashSignature = model.CashSignature,
                    DD_BankName_Branch = model.DD_BankName_Branch,
                    DD_Date = model.DD_Date,
                    InstrumentNo = model.InstrumentNo,
                    Debit_Credit_Card = model.Debit_Credit_Card,
                    EMIOpted = model.EMIOpted,
                    EmiAmount=model.EmiAmount,
                     QRCode=model.QRCode,
                   
                    EmiStartDate = model.EmiStartDate,
                    ClubValero_Executive = model.ClubValero_Executive,
                    Individual = model.Individual,
                    Co_applicant_kyc = model.Co_applicant_kyc,
                    CVE_ID = model.CVE_ID,
                    TenureDate= model.TenureDate,
                    CreateByDate= model.CreateByDate,
                    KYC_Date = model.KYC_Date 
                    

                };
                _context.Members.Add(emp);
                _context.SaveChanges();

                for(int i=1;i<=Convert.ToInt32(model.EMIOpted);i++)
                {
                    UserEmi emp1 = new UserEmi()
                    {
                        UserName=model.M_FirstName,
                        Amount=model.EmiAmount,
                        Status="due",
                        UserId=emp.Id,
                        EmiDepositDate=DateTime.Now,
                        PaymentMode="",
                        EmiStartDate=DateTime.Now.AddMonths(i)
                    };
                    _context.UserEmis.Add(emp1);
                    _context.SaveChanges();
                }

                for (int i = 1; i <= Convert.ToInt32(model.Tenure); i++)
                {
                    UserAmc emp1 = new UserAmc()
                    {
                        UserName = model.M_FirstName,
                        Amount = model.AmcCharge,
                        Status = "due",
                        UserId = emp.Id,
                        AmcDepositDate=DateTime.Now,
                        PaymentMode="",
                        AmcStartDate =DateTime.Now.AddYears(i)
                    };
                    _context.UserAmcs.Add(emp1);
                    _context.SaveChanges();
                }

                //if (model.TenureDate !=model.CreateByDate)
                //{
                //    List<int> count = new List<int>();
                //    foreach(int item in model.CreateByDate)
                //    {
                //        count.Add(item);
                //    }
                //}

                string mobilesms = "Thank you for choosing India's favorite holiday company, Club Valero, that gives you and your family magical experiences year after year. So hop onboard and start exploring! Your User ID:'"+emp.MemberShipId+"' and Password : '"+emp.Password+"'";
                
                
                Mobilesms.SendSms(model.Mobile, mobilesms);

                //string Emlsms = "Welcome To CLUB-VELERO Member Your UserName:" + emp.MemberShipId + ": And Password Is:" + emp.Password + "";


                string Emailsms = "Thank you for choosing India's favorite holiday company, Club Valero, that gives you and your family magical experiences year after year. So hop onboard and start exploring! Your User ID: '"+emp.MemberShipId+"' and Password : '"+emp.Password+"' For any query: info @clubavlero.com  For booking: bookings @clubvalero.com Keep Holidaying!!!";
                
                Emailmsg.SendEmail(emp.Email, Emailsms);
              
            }
            catch
            {
                throw new Exception("Somthing Error");
                
            }
        }
   
        public bool Updatemember(MemberViewModel model)
        {
            try
            {
                var result = _context.Members.FirstOrDefault(x => x.Id == model.Id);
                if(result !=null)
                {
                    //result.MemberShipId = Gid.MemberShipId();
                    result.MemberShipId = model.MemberShipId;
                    //result.Password = Guid.NewGuid().ToString().Substring(0, 6);
                    result.M_FirstName = model.M_FirstName;
                    result.M_LastName = model.M_LastName;                    
                    result.M_Gender = model.M_Gender;
                    result.M_DateOfBirth = model.M_DateOfBirth;
                    result.M_Salution = model.M_Salution;
                    result.Age = model.Age;
                   
                   
                    result.MaritalStatus = model.MaritalStatus;
                    result.Occupation = model.Occupation;
                    result.AnnualIncome = model.AnnualIncome;
                    result.FoodPreference = model.FoodPreference;
                    result.Co_Salution = model.Co_Salution;
                    result.Co_Gender = model.Co_Gender;
                    result.Co_FirstName = model.Co_FirstName;

                    
                    result.Co_LastName = model.Co_LastName;
                    result.Co_Mobile = model.Co_Mobile;
                    result.Co_Email = model.Co_Email;
                    result.No_Co_Adults = model.No_Co_Adults;
                    result.No_Co_Children = model.No_Co_Children;
                    result.Co_Child1 = model.Co_Child1;
                    result.Co_Child1_DateOfBirth = model.Co_Child1_DateOfBirth;
                    result.Co_Child2 = model.Co_Child2;
                    result.Co_Child2_DateOfBirth = model.Co_Child2_DateOfBirth;
                    result.Co_Child3 = model.Co_Child3;
                    result.Co_Child3_DateOfBirth = model.Co_Child3_DateOfBirth;
                    result.NameOfPremission_Building = model.NameOfPremission_Building;
                    result.Road_Street_Lane = model.Road_Street_Lane;
                    result.Area_Locality = model.Area_Locality;
                    result.LandMark = model.LandMark;
                    result.State = model.State;
                    result.City = model.City;
                    result.Country = model.Country;
                    result.PinCode = model.PinCode;
                    result.Mobile = model.Mobile;
                    result.Email = model.Email;
                    result.ApptType = model.ApptType;
                   
                    result.NoOf_Night_Year = model.NoOf_Night_Year;
                    result.Occupants = model.Occupants;
                   result.MemberShipType = model.MemberShipType;
                    result.AmcCharge = model.AmcCharge;
                    result.ClubValeroMemebr = model.ClubValeroMemebr;
                    result.MemberShipNo = model.MemberShipNo;
                    result.MemberShip_Price = model.MemberShip_Price;                  
                   
                    result.BalanceAmount = model.BalanceAmount;
                  
                    result.ModeOfPayment = model.ModeOfPayment;
                    result.CashDate = model.CashDate;
                    result.CashAmount = model.CashAmount;
                    result.CashReceiptNo = model.CashReceiptNo;
                    result.CashSignature = model.CashSignature;
                    result.DD_BankName_Branch = model.DD_BankName_Branch;
                    result.DD_Date = model.DD_Date;
                   result.InstrumentNo = model.InstrumentNo;
                    result.Debit_Credit_Card = model.Debit_Credit_Card;
                                   
                   result.ClubValero_Executive = model.ClubValero_Executive;
                    result.Individual = model.Individual;
                    result.Co_applicant_kyc = model.Co_applicant_kyc;
                   result.CVE_ID = model.CVE_ID;
                    result.KYC_Date = model.KYC_Date;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Something Went Wrong");
            }
        }
    
        public bool DeleteMember(int id)
        {
            try
            {
                var data = _context.Members.FirstOrDefault(x => x.Id == id);
                if(data!=null)
                {
                    _context.Members.Remove(data);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public bool AmcPayment(UserAmc model)
        {
            try
            {
                var result = _context.UserAmcs.FirstOrDefault(x => x.Id == model.Id);
                if(result !=null)
                {
                    result.Amount = model.Amount;
                    result.Status = "paid";
                    result.PaymentMode = model.PaymentMode;
                    result.AmcDepositDate = DateTime.Now;
                    result.remarks = model.remarks;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AmcPaymentOnline(int id)
        {
            try
            {
                var result = _context.UserAmcs.FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    result.Amount = result.Amount;
                    result.Status = "paid";
                    result.PaymentMode = "Online";
                    result.AmcDepositDate = DateTime.Now;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EmiPayment(UserEmi model)
        {
            try
            {
                var result = _context.UserEmis.FirstOrDefault(x => x.Id == model.Id);
                if(result !=null)
                {
                    result.Amount = model.Amount;
                    result.Status = "paid";
                    result.PaymentMode = model.PaymentMode;
                    result.EmiDepositDate = DateTime.Now;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EmiPaymentOnline(int id)
        {
            try
            {
                var result = _context.UserEmis.FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    result.Amount = result.Amount;
                    result.Status = "paid";
                    result.PaymentMode = "Online";
                    result.EmiDepositDate = DateTime.Now;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }       

        public bool AddContactus(ContactUsModel model)
        {
            try
            {
                ContactUs emp = new ContactUs()
                {
                    Name=model.Name,
                    Email=model.Email,
                    Mobile=model.Mobile,
                    Subject=model.Subject,
                    Message=model.Message
                };
                _context.contacts.Add(emp);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ForGatePassWord(int id)
        {
            try
            {
                var result = _context.Members.FirstOrDefault(x => x.Id == id);
                if(result!=null)
                {
                    result.Password = Guid.NewGuid().ToString().Substring(0, 6);
                    _context.SaveChanges();
                    string Msg = "Club-Valero Member Your UserName:"+result.MemberShipId+": Password:"+result.Password+"- Thank You";

                    Emailmsg.SendEmail(result.Email, Msg);
                    return true;                    
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    
    
        public bool WelComeEmail(int id)
        {
            try
            {
                var result = _context.Members.FirstOrDefault(x => x.Id == id);
                if(result !=null)
                {
                    string msg = "Ms. '"+result.M_FirstName+"' Mobile: '"+result.Mobile+"' Customer ID: '"+result.MemberShipId+"' Dear Ms. '"+result.M_FirstName+"' Greetings from Club Valero!!";

                    msg += " Welcome to Club Valero.We are delighted that you have chosen us to deliver a million smiles for you and your family which is why we promise you the Joy of Discovery in every holiday you experience with us.";

                    msg += " At Club Valero, Holidays are not only about spending quality time with your loved ones, but also discovering new joys.With this is mind we welcome you abroad to rekindle spirit of adventure, the desire of new sights, the curiosity to explore new destination and culture, respect for nature and most of all appreciate the multitude of tastes and experience at all our charming destination.";

                    msg += " Your Club Valero Package Details is as below:-";
                    msg += "Customer ID - '"+result.MemberShipId+"' Customer Name - '"+result.M_FirstName+"' & Co - Applicant - '"+result.M_FirstName+"', Eligible Nights Per Year - 6N / 7D | CVHP - 5 Years'"+result.Tenure+"' '"+result.CreateByDate+"' To '"+result.TenureDate+"' Room Occupancy -Studio, 2 adults & 2 children(Below 10 years) or 3 Adults. '"+result.No_Co_Adults+"'";
                    msg += "Special Offer :-2 Air Tickets Return 3 Nights Stay in India With Breakfast & Dinner. '"+result.FoodPreference+"'";
                    msg += "Membership Rights & Benefits: -";
                    msg += "1.) Member can split his/ her holidays, Minimum 2 nights booking required for single holiday.";
                    msg += "2.) Member can transfer his/ her membership any point of time.";
                    msg += "3.) Member can take holiday in advance from next year.";
                    msg += "4.) Holiday can be carried forward up to 2 years.";
                    msg += "Package Cost:  '"+result.ParchagePrice+"' AMC - '"+result.AmcCharge+"' Per Year";
                    msg += "Exchange Fee – As Applicable";
                    msg += "India - 999 / Night";
                    msg += "Asia - 1999 / Night";
                    msg += "Worldwide - 2999 / Night";
                    msg += "Your Payment Detail:";
                    msg += "  Rs.90,000 / -(dynamic)by(45000 Cash + 45000 NEFT)(dynamic)";
                    msg += " Blackout days: 20 Dec to 10th Jan.";
                    msg += "We have dedicated Team who can assist you is your holiday planning and any queries regarding your package, they can be contacted at 8448440705(10.00 am to 6.00 pm Except Sunday & National Holidays).You could also email us at bookings@clubvalero.com.";
                    msg += "We have a E-Welcome kit for our delighted customers which consist of a Welcome Letter, Package certificate and card and it will be delivered to your address or your email address.";
                    msg += "As we all knows that The Covid - 19 situation has evolved further and we are dealing with significant global challenge.During this time of uncertainty, we will do everything we can to support our community around the world.";
                    msg += "We look forward to having you and your family vacation with us soon.";
                    msg += "Happy Holidays!";
                    msg += "Thanks & Regards";
                    msg += "MR Team";
                    msg += "Club Valero -www.clubvalero.com";
                    msg += "404, 4th Floor, DDA Building - 5, District Centre, Janakpuri, New Delhi - 110058";
                    msg += " Tel: +91 11 – 43023506 / 7042697042 / 8448440705(Office timings: 10.00 am to 6.00 pm) except Sunday and National Holiday";
                 
                  
                  bool isvalid =   Emailmsg.SendEmail(result.Email, msg);
                    if(isvalid)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public void PdfUploadBL(Member model)
        {

            var emp = _context.Members.FirstOrDefault(x => x.Id == model.Id);
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(model.postedFile.InputStream))
            {
                bytes = br.ReadBytes(model.postedFile.ContentLength);
            }

            if (emp != null)
            {
                emp.FileName = Path.GetFileName(model.postedFile.FileName);
                emp.ContentType = model.postedFile.ContentType;
                emp.Data = bytes;
            }
            _context.SaveChanges();
        }


        public bool AddCitiesName(IndianCity model)
        {
            try
            {
                IndianCity emp = new IndianCity()
                {
                    Name = model.Name
                };
                _context.IndianCities.Add(emp);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddIndianFullCity(IndianFullCityPageModel model)
        {
            try
            {
                IndianFullCityPage emp = new IndianFullCityPage()
                {
                    IndianCityId=model.IndianCityId,
                    CityDescription=model.CityDescription
                };
                _context.indianFullCityPages.Add(emp);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IndianListDelete(int id)
        {
            try
            {
                var result = _context.IndianCities.FirstOrDefault(x => x.Id == id);
                if(result!=null)
                {
                    _context.IndianCities.Remove(result);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool AddAsia(AsiaModel model)
        {
            try
            {
                Asia emp = new Asia()
                {
                    AsiaName = model.AsiaName
                };
                _context.Asianames.Add(emp);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAsia(int id)
        {
            try
            {
                var result = _context.Asianames.FirstOrDefault(x => x.Id == id);
                if(result !=null)
                {
                    _context.Asianames.Remove(result);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    
        public bool HotelBooking(BookingModel model)
        {
            try
            {
                Booking emp = new Booking()
                {
                    UserId=model.UserId,
                    CheckIn=model.CheckIn,
                    CheckOut=model.CheckOut,
                    Nights=model.Nights,
                    Days=model.Days,
                    City=model.City,
                    HolidayType=model.HolidayType,
                    Hotel=model.Hotel,
                    Address=model.Address,
                    TelephoneNo=model.TelephoneNo,
                    ConfirmationId=model.ConfirmationId,
                    RoomType=model.RoomType,
                    Remarks=model.Remarks,
                    ConfirmedBy=model.ConfirmedBy,
                    NoOfRooms=model.NoOfRooms,
                    NoOfKids=model.NoOfKids,
                    NoOfAdult=model.NoOfAdult,
                    MealPlan=model.MealPlan
                };
                _context.bookings.Add(emp);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public bool UpdateBooking(Booking model)
        {
            try
            {
                var result = _context.bookings.FirstOrDefault(x => x.Id == model.Id);
                if(result !=null)
                {
                    result.HolidayType = model.HolidayType;
                    result.Days = model.Days;
                    result.Hotel = model.Hotel;
                    result.MealPlan = model.MealPlan;
                    result.Nights = model.Nights;
                    result.NoOfAdult = model.NoOfKids;
                    result.NoOfKids = model.NoOfKids;
                    result.NoOfRooms = model.NoOfRooms;
                    result.PaymentStatus = model.PaymentStatus;
                    result.Remarks = model.Remarks;
                    result.UserId = model.UserId;
                    result.TelephoneNo = model.TelephoneNo;
                    result.RoomType = model.RoomType;
                    result.Address = model.Address;
                    result.CheckIn = model.CheckIn;
                    result.CheckOut = model.CheckOut;
                    result.ConfirmationId = model.ConfirmationId;
                    result.ConfirmedBy = model.ConfirmedBy;
                        
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool AddMessage(Message model)
        {
            try
            {
                Message emp = new Message()
                {
                    Name=model.Name,
                    MobileNo=model.MobileNo,
                    Email = model.Email,
                    Time = model.Time,
                    //Profission =model.Profission,
                    Address=model.Address
                };
                _context.messages.Add(emp);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
            
        }


        public bool HotelBookingForUser(BookingModel model,int id)
        {
            try
            {
                Booking emp = new Booking()
                {   UserId=id,              
                    CheckIn = model.CheckIn,
                    CheckOut = model.CheckOut,
                    Nights = model.Nights,
                    Days = model.Days,
                    City = model.City,
                    HolidayType = model.HolidayType,
                    Hotel = model.Hotel,
                    Address = model.Address,
                    TelephoneNo = model.TelephoneNo,
                    ConfirmationId = model.ConfirmationId,
                    RoomType = model.RoomType,
                    ConfirmedBy = model.ConfirmedBy,
                    NoOfRooms = model.NoOfRooms,
                    NoOfKids = model.NoOfKids,
                    NoOfAdult = model.NoOfAdult,
                    MealPlan = model.MealPlan
                };
                _context.bookings.Add(emp);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddRemark(RemarkModel model)
        {
            try
            {
                Remark emp = new Remark()
                {
                    CreateRemark = model.CreateRemark,
                    CreateDate=model.CreateDate,
                    CurrentDate=DateTime.Now,
                    UserId = model.UserId
                };
                _context.remarks.Add(emp);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditRemark(Remark model)
        {
            try
            {
                var result = _context.remarks.FirstOrDefault(x => x.Id == model.Id);
                if(result !=null)
                {
                    result.CreateRemark = model.CreateRemark;
                    result.CurrentDate = DateTime.Now;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
