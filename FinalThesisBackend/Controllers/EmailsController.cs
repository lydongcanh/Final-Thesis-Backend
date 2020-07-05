using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalThesisBackend.Core.ValueObjects;

namespace FinalThesisBackend.Controllers
{
    [Route("api/[controller]")]
    public class EmailsController : Controller
    {
        [HttpPost]
        public virtual IActionResult Post([FromBody] Email email)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("keshiki.ldc@gmail.com", "sangnelan");


                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("keshiki.ldc@gmail.com", "Đồ án tốt nghiệp"),
                    Subject = email.Subject,
                    Body = email.Body
                };

                mail.To.Add(new MailAddress(email.To));
                smtpClient.Send(mail);

                smtpClient.Dispose();
                mail.Dispose();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound(e);
            }
        }
    }
}
