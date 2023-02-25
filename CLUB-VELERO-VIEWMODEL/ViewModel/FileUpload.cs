using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CLUB_VELERO_VIEWMODEL.ViewModel
{
   public class FileUpload
    {
        int Id { get; set; }
        public HttpPostedFileBase files { get; set; }

    }
}
