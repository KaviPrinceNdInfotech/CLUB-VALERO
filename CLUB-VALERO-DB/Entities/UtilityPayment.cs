using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB_VALERO_DB.Entities
{
    public class UtilityPayment
    {
        [Key]
        public int Id { get; set; }
        public string Amount { get; set; }
    }
}
