using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CLUB_VELERO_VIEWMODEL.ViewModel
{
   public class MemberViewModel
    {
  
        //Member Details//
        public int Id { get; set; }
        /* Member Name  M Means Member Details*/
      
        public string M_FirstName { get; set; }

        public string M_MiddleName { get; set; }
      
        public string M_LastName { get; set; }
    
        public string M_Gender { get; set; }
       
        public string M_DateOfBirth { get; set; }

        public string M_Salution { get; set; }

        public string Age { get; set; }

        public string MaritalStatus { get; set; }

        public string Occupation { get; set; }
    
        public string AnnualIncome { get; set; }

        public string FoodPreference { get; set; }

        //Co-Applicant (Spouse) Details//

        public string Co_Salution { get; set; }
        public string Co_Gender { get; set; }
        /*Co-Applicant Name*/
      
        public string Co_FirstName { get; set; }

        public string Co_MiddleName { get; set; }

      
        public string Co_LastName { get; set; }
      
        public string Co_Mobile { get; set; }
      
        public string Co_Email { get; set; }
       
        public string No_Co_Adults { get; set; }
       
        public string No_Co_Children { get; set; }
        public string Co_Child1 { get; set; }
        public string Co_Child1_DateOfBirth { get; set; }
        public string Co_Child2 { get; set; }
        public string Co_Child2_DateOfBirth { get; set; }
        public string Co_Child3 { get; set; }
        public string Co_Child3_DateOfBirth { get; set; }

        //Communication Address/ Permanent Address & Contact Details//

        public string NameOfPremission_Building { get; set; }

        public string Road_Street_Lane { get; set; }

        public string Area_Locality { get; set; }

        public string LandMark { get; set; }
        
        public string State { get; set; }
     
        public string City { get; set; }
      
        public string Country { get; set; }

        public string PinCode { get; set; }
     
        public string Mobile { get; set; }
      
        public string Email { get; set; }


        ///ProDuct Details////

        public string ApptType { get; set; }
        public string Tenure { get; set; }
   
        public string NoOf_Night_Year { get; set; }

        public string Occupants { get; set; }
        public string TenureDate { get; set; }

        public string CreateByDate { get; set; }

        public string MemberShipType { get; set; }

        public string AmcCharge { get; set; }

        //Enrollment Benifits//
        public string ClubValeroMemebr { get; set; }

        public string MemberShipNo { get; set; }

        //Payment Details//
        public string MemberShip_Price { get; set; }

        public string AdminFee { get; set; }
        public string DownPayment { get; set; }
        public string BalanceAmount { get; set; }
        public string DownPaymentOpted { get; set; }
        public string ModeOfPayment { get; set; }
        public string CashDate { get; set; }
        public string CashAmount { get; set; }
        public string CashReceiptNo { get; set; }
        public string CashSignature { get; set; }

        public string DD_BankName_Branch { get; set; }

        public string DD_Date { get; set; }

        public string DD_InstrumentNo { get; set; }

        public string Debit_Credit_Card { get; set; }

        //EMI Plan///
        public string EMIOpted { get; set; }

        public string Emi_BankName { get; set; }
        public string Emi_InstrumentNo { get; set; }
        public string Emi_Plan_Date { get; set; }

        //KYC Documents //
        public string Individual { get; set; }

        public string Co_applicant_kyc { get; set; }


        public string ClubValero_Executive { get; set; }
        public string CVE_ID { get; set; }

        public string KYC_Date { get; set; }

        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public HttpPostedFileBase postedFile { get; set; }
    }
}
