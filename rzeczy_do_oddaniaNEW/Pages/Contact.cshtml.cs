using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rzeczy_do_oddaniaNEW.Pages.Models;
using System.Net.Mail;

namespace rzeczy_do_oddaniaNEW.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
        }

        public Email sendmail { get; set; }

        public async Task OnPost() {
            string To = sendmail.To;
            string Subject = sendmail.Subject;
            string Body = sendmail.Body;
            MailMessage mm = new MailMessage();
            mm.To.Add(To);
            mm.Subject = Subject;
            mm.Body = Body;
            mm.IsBodyHtml = false;
            mm.From = new MailAddress("81137@student.pb.edu.pl");
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp-relay.sendinblue.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("81137@student.pb.edu.pl", "password");
            ViewData["Message"] = "Mail has been sent to " + sendmail.To;

        }
    }
}
