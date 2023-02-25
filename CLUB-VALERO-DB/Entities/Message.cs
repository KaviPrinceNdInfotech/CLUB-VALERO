using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB_VALERO_DB.Entities
{
   public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Profission { get; set; }

    }
}
