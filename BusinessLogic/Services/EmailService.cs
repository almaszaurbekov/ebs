using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string message);
    }

    public class EmailService : IEmailService
    {
        private IConfiguration Configuration;
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

        public EmailService(IConfiguration configuration)
        {
            SetUpConfiguration(configuration);
        }

        public void SetUpConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
            SetUpService();
            SetUpSmtpClient();
        }

        public async Task SendEmailAsync(string email, string message)
        {
            SetUpEmail(email, message);
            await SmtpClient.SendMailAsync(Message);
        }

        private void SetUpService()
        {
            Address = Configuration["EmailService:Address"];
            DisplayName = Configuration["EmailService:DisplayName"];
            EmailPassword = Configuration["EmailService:Password"];
            Host = Configuration["EmailService:Host"];
            Port = Convert.ToInt32(Configuration["EmailService:Port"]);
            Subject = Configuration["EmailService:Subject"];
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
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Credentials = new NetworkCredential(Address, EmailPassword);
            SmtpClient.EnableSsl = true;
        }
    }
}
