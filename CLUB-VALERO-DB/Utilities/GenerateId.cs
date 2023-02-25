using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLUB_VALERO_DB.DbContext_DB;
namespace CLUB_VALERO_DB.Utilities
{
   public class GenerateId
    {
        private DBContextClub _context = new DBContextClub();

        public string MemberShipId()
        {
            var data = _context.Members.OrderByDescending(a => a.MemberShipId).FirstOrDefault();
            string Id = "VFF/VCH/1001";
            if(data!=null)
            {
                string PartitionValue = data.MemberShipId.Substring(8, data.MemberShipId.Length - 8);
                int IncrementedVal = Convert.ToInt32(PartitionValue) + 1;

                return "VFF/VCH/" + IncrementedVal;
            }
            return Id;
        }
    }
}
