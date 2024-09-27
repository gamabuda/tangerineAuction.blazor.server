using System;
using System.Net;
using System.Net.Mail;

namespace tangerineAuction.blazor.server.Service
{
    public class MailSenderService
    {
        public async Task SendEmail(string recipient, string subject, string body)
        {
            MailAddress fromM = new MailAddress("testmailc704@gmail.com", "Mandarinka");
            MailAddress toM = new MailAddress(recipient);

            using (MailMessage message = new MailMessage(fromM, toM))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                message.IsBodyHtml = true;
                message.Subject = subject;
                message.Body = body;

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromM.Address, "tiynfzsgkckbwypq");

                await smtpClient.SendMailAsync(message);
            }
        }
    }
}

