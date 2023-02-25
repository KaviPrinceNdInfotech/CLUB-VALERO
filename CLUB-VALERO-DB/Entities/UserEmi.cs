using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB_VALERO_DB.Entities
{
   public class UserEmi
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }

        public string PaymentMode { get; set; }

        public DateTime EmiStartDate { get; set; }

        public DateTime EmiDepositDate { get; set; }
        public int UserId { get; set; }
    }
}
