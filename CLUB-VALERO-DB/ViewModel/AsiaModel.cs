using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CLUB_VALERO_DB.ViewModel
{
   public class AsiaModel
    {
        [Key]
        public int Id { get; set; }
        [AllowHtml]
        public string AsiaName { get; set; }
    }
}
