using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string message, IConfiguration configuration);
    }

    public class EmailService : IEmailService
    {
        private string Address { get; set; }
        private string DisplayName { get; set; }
        private string EmailPassword { get; set; }
        private string Host { get; set; }
        private int Port { get; set; }
        private string Subject { get; set; }
        private MailAddress Sender { get; set; }
        private MailAddress Recipient { get; set; }
        private MailMessage Message { get; set; }
        private SmtpClient SmtpClient { get; set; }

        public async Task SendEmailAsync(string email, string message, IConfiguration configuration)
        {
            SetUpService(configuration);
            SetUpEmail(email, message);
            SetUpSmtpClient();
            await SmtpClient.SendMailAsync(Message);
        }

        private void SetUpService(IConfiguration configuration)
        {
            Address = configuration["EmailService:Address"];
            DisplayName = configuration["EmailService:DisplayName"];
            EmailPassword = configuration["EmailService:Password"];
            Host = configuration["EmailService:Host"];
            Port = Convert.ToInt32(configuration["EmailService:Port"]);
            Subject = configuration["EmailService:Subject"];
        }

        private void SetUpEmail(string email, string message)
        {
            Sender = new MailAddress(Address, DisplayName);
            Recipient = new MailAddress(email);
            Message = new MailMessage(Sender, Recipient);

            Message.Subject = Subject;
            Message.Body = message;
            Message.IsBodyHtml = true;
        }

        private void SetUpSmtpClient()
        {
            SmtpClient = new SmtpClient(Host, Port);
            SmtpClient.Credentials = new NetworkCredential(Address, EmailPassword);
            SmtpClient.EnableSsl = true;
        }
    }
}
