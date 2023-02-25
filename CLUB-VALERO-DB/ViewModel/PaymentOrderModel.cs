using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB_VALERO_DB.ViewModel
{
   public class PaymentOrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string UserId { get; set; }
        public string Mobileno { get; set; }
        public string EmailId { get; set; }
        public string Amount { get; set; }
        public string PaymentType { get; set; }

        public string Mobile { get; set; }
        public string DateTime { get; set; }
        public string M_FirstName { get; set; }
        public string State { get; set; }


        public string City { get; set; }
        public string M_LastName { get; set; }
        public string PinCode { get; set; }
    }
}
