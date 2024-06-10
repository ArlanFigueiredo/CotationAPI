using System.Net.Mail;

namespace Cotation.Infrastructure.EmailService {
    public class SendTestEmail {
        public MailMessage SenderTestEmail(string subject, string body, string to) {
            //Attachment attachment = new("C:/Users/arlan/Downloads/Cotação Ellen.pdf");
            MailMessage mailMessage = new() {
                From = new MailAddress("arlan.carloz@gmail.com"),
                Subject = subject,
                Body = body,
                
            };
            //Adicionando link do anexo ao escopo
            //mailMessage.Attachments.Add(attachment);
            mailMessage.To.Add(new MailAddress(to));
            //mailMessage.To.Add(new MailAddress("anacarolinemarques18@gmail.com"));
            return mailMessage;
        }
    }
}
