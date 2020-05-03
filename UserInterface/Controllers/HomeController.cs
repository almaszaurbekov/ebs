using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common;
using UserInterface.ViewModels;

namespace UserInterface.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "User");
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Training()
        {
            return View();
        }

        /// <summary>
        /// Подписка на еженедельные новости
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(string email)
        {
            try
            {
                MailAddress from = new MailAddress("kz.ebooksharing@gmail.com", "kz.ebooksharing@gmail.com");
                MailAddress to = new MailAddress(email);
                MailMessage message = new MailMessage(from, to);
                message.Subject = "EBookSharing - Weekly news";
                message.Body = "<h2>Спасибо большое за подписку!</h2>";
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("kz.ebooksharing@gmail.com", PasswordHelper.EmailPassword());
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return Redirect("Index?subscribed=yes");
            }
            catch (Exception e)
            {
                return Redirect("Index?subscribed=no");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
