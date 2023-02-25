using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CLUB_VALERO_DB.ViewModel
{
   public class IndianFullCityPageModel
    {
        public int Id { get; set; }
        public int IndianCityId { get; set; }
        [AllowHtml]
        public string CityDescription
        {
            get; set;
        }
    }
}
