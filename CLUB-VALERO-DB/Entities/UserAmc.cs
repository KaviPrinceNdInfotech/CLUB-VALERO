using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB_VALERO_DB.Entities
{
   public class UserAmc
    {
        [Key]
        public int Id { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public DateTime AmcStartDate { get; set; }
        public int UserId { get; set; }
        public DateTime AmcDepositDate { get; set; }

        public string PaymentMode { get; set; }

        public IEnumerable<Member> Servicelist { get; set; }
    }
}
