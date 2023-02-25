using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB_VALERO_DB.Entities
{
   public class Remark
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreateRemark { get; set; }
        public string CreateDate { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
