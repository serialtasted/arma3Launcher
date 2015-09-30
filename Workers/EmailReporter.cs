using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace arma3Launcher.Workers
{
    class EmailReporter
    {
        public EmailReporter()
        {

        }

        public void sendReport(string message)
        {
            MailMessage eReport = new MailMessage();
            var eSmtp = new SmtpClient("in-v3.mailjet.com", 25)
            {
                Credentials = new NetworkCredential("3934e3893340d8bd2a4dab154a7c6c22", "e2cbd64011356374bdda9caf80b5f5d6")
            };

            eReport.To.Add("rodrigo.taveira.levy@gmail.com");
            eReport.Subject = "spN Launcher";
            eReport.From = new MailAddress("rodrigo.taveira.levy@gmail.com");

            eReport.Body = message;

            eSmtp.SendMailAsync(eReport);
        }
    }
}
