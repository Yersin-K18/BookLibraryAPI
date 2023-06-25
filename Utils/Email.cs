using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace BookLibraryAPI.Utils
{
    public class Email
    {
        public static async Task<bool> SendMail(string to, string subject, string body)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("hoang3409@alwaysdata.net"));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = body };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp-hoang3409.alwaysdata.net", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("hoang3409@alwaysdata.net", "k8eHarwdXQH.AJg");
                await smtp.SendAsync(email);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
