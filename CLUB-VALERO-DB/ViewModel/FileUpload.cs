using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CLUB_VALERO_DB.ViewModel
{
   public class FileUpload
    {
        int Id { get; set; }
        public HttpPostedFileBase files { get; set; }
    }
}
