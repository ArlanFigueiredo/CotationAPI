using System.Net;
using System.Net.Mail;

namespace Cotation.Infrastructure.EmailService {
    public class SettingsEmailService {

        public async Task OnConfigurateSendEmailService(MailMessage mailMessage) {

            SmtpClient smtpClient = new("smtp.gmail.com", 587) {
                EnableSsl = true, // Habilitar SSL/TLS
               
            };
            smtpClient.Send(mailMessage);

            Console.WriteLine("Email enviado com sucesso!");
        }
    }
}

