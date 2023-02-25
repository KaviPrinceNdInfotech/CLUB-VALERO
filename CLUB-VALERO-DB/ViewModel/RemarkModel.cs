using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLUB_VALERO_DB.ViewModel
{
    public class RemarkModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreateRemark { get; set; }
        public string CreateDate { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
