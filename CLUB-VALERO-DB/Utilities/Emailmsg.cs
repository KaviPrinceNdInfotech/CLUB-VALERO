using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CLUB_VALERO_DB.Utilities
{
    public class Emailmsg
    {
        public static bool SendEmail(string reciever, string Message)
        {
            string UserEmail = "";
            string password = "";

            try
            {
                MailMessage msg = new MailMessage(UserEmail, reciever);
                msg.Body = Message;
                msg.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential(UserEmail, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(msg);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
