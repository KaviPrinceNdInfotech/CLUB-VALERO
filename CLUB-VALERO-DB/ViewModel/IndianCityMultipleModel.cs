using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CLUB_VALERO_DB.Entities;
namespace CLUB_VALERO_DB.ViewModel
{
    class IndianCityMultipleModel
    {
        public int Id { get; set; }
        public int IndianCityId { get; set; }
        [AllowHtml]
        public string CityDescription{get; set;}

        public List<IndianFullCityPage> indianFullCityPagesmodel { get; set; }

        public List<IndianCity> indianCitiesmodel { get; set; }
    }
}
