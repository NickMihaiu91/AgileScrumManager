using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AgileManager.Web.Utils
{
    public static class UtilMethods
    {
        public static void SendEmail(string toEmailAddress, string subject, string body)
        {
            var repo = new EmailServerRepository();
            var emailServer = repo.GetEmailServer();

            var fromAddress = new MailAddress(emailServer.EmailAddress, "Agile Scrum Manager Registration");
            var toAddress = new MailAddress(toEmailAddress);
            string fromPassword = emailServer.EmailPassword;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}