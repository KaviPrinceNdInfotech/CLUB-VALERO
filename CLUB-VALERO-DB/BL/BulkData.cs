using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLUB_VALERO_DB.Entities;
using CLUB_VALERO_DB.DbContext_DB;
namespace CLUB_VALERO_DB.BL
{
   public class BulkData
    {
        private DBContextClub db = new DBContextClub();
        public bool AddBulkLoginAndRole()
        {
            try
            {
                var roleMange = (from s in db.Rolemastes select s).Count();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
