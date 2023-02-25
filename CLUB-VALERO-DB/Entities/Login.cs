using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using CLUB_VALERO_DB.Entities;
namespace CLUB_VALERO_DB.Entities
{
   public class Login
    {
        [Key]
        public int Id { get; set; }
      
        public string UserName { get; set; }
       
        public string Password { get; set; }
       
        public int RoleMasterId { get; set; }
        [ForeignKey("RoleMasterId")]
        public virtual RoleMaster rolemaster { get; set; }
        
    }
}
