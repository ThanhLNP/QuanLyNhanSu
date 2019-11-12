using CaseStudy.Domain.Request.Email;
using CaseStudy.Domain.Request.SendEmailRequest;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CaseStudy.BAL
{
    public class EmailService : EmailConfig
    {
        public EmailService()
        {

        }
        public static bool Send(SendEmailRequest request)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(EmailConfig.senderEmail, EmailConfig.SenderPassword),
                    EnableSsl = true
                };

                MailMessage mail = new MailMessage(new MailAddress(EmailConfig.senderEmail, EmailConfig.NameEmail, System.Text.Encoding.UTF8),
                    new MailAddress(string.IsNullOrWhiteSpace(request.ToEmail) ? EmailConfig.senderEmail : request.ToEmail))
                {
                    Subject = request.subject,
                    Body = request.body,
                    IsBodyHtml = true,
                    DeliveryNotificationOptions  = DeliveryNotificationOptions.OnFailure,
                    SubjectEncoding = System.Text.Encoding.UTF8
                };

                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
