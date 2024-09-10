using Microsoft.Extensions.Options;
//using System.Net.Mail;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using TerminalMonitoringSolution.IServices;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Net.Sockets;
using MailKit;

namespace TerminalMonitoringSolution.Services
{
    public class SmtpDetails
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }

    public class EmailService : IEmailService
    {
        private readonly SmtpDetails _smtpDetails;

        public EmailService(IOptions<SmtpDetails> smtpSettings)
        {
            _smtpDetails = smtpSettings.Value;
        }


        public bool CheckSmtpConnection(string smtpServer, int smtpPort)
    {
        using (var client = new TcpClient())
        {
            try
            {
                client.ConnectAsync(smtpServer, smtpPort);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtpDetails.SenderName, _smtpDetails.SenderEmail));

            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            var connect = CheckSmtpConnection("smtp.gmail.com", 465);

            try
            {
                using (var client = new SmtpClient(new ProtocolLogger(Console.OpenStandardOutput())))
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(_smtpDetails.SmtpServer, _smtpDetails.SmtpPort, SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(_smtpDetails.SmtpUsername, _smtpDetails.SmtpPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch
            {

            }
        }
    }
}
