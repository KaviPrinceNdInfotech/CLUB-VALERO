using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CLUB_VALERO_DB.Entities
{
   public class IndianFullCityPage
    {
        [Key]
        public int Id { get; set; }
        public int IndianCityId { get; set; }
      
        public string CityDescription
        {
            get;set;
        }
    }
}
