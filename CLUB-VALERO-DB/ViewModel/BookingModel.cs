using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CLUB_VALERO_DB.ViewModel
{
    public class BookingModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string CheckOut { get; set; }
        public string CheckIn { get; set; }
        public string Nights { get; set; }
        public string Days { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public string Address { get; set; }
        public string TelephoneNo { get; set; }
        public string ConfirmationId { get; set; }
        public string RoomType { get; set; }
        public string ConfirmedBy { get; set; }
        public string NoOfRooms { get; set; }
        public string NoOfKids { get; set; }
        public string PaymentStatus { get; set; }
        public string Remarks { get; set; }
        public string HolidayType { get; set; }
        public string MealPlan { get; set; }
        public string NoOfAdult { get; set; }
        public string Noofnights { get; set; }


    }
}
