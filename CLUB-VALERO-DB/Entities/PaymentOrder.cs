using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB_VALERO_DB.Entities
{
    public class PaymentOrder
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string UserId { get; set; }
        public string Mobileno { get; set; }
        public string EmailId { get; set; }
        public string Amount { get; set; }
        public string PaymentType { get; set; }       
        public string DateTime { get; set; }     
    }
}
