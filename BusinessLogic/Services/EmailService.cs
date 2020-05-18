using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IEmailService { }
    public class EmailService
    {
        private string Address { get; set; }
        private string DisplayName { get; set; }
        private string EmailPassword { get; set; }
        private string Host { get; set; }
        private int Port { get; set; }

        public EmailService(IConfiguration configuration)
        {
            Address = configuration["Address"];
            DisplayName = configuration["DisplayName"];
            EmailPassword = configuration["Password"];
            Host = configuration["Host"];
            Port = Convert.ToInt32(configuration["Port"]);
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailAddress from = new MailAddress(Address, DisplayName);
            MailAddress to = new MailAddress(email);
            MailMessage _message = new MailMessage(from, to);

            _message.Subject = subject;
            _message.Body = message;
            _message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(Host, Port);
            smtp.Credentials = new NetworkCredential(Address, EmailPassword);
            smtp.EnableSsl = true;

            await smtp.SendMailAsync(_message);
        }
    }
}
