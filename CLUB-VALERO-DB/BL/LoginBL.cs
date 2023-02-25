using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLUB_VALERO_DB.Entities;
using CLUB_VALERO_DB.ViewModel;
using CLUB_VALERO_DB.DbContext_DB;
namespace CLUB_VALERO_DB.BL
{
   public class LoginBL
    {
         DBContextClub _context = new DBContextClub();
        public bool Login(LoginModel model)
        {
            try
            {
               
                //var role = _context.Logins.Where(x => x.UserName == model.UserName && x.Password == model.Password).Select(x => new LoginModel()
                //{
                //    LoginRole = x.LoginRole,
                //    UserName = x.UserName
                //}).FirstOrDefault();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
