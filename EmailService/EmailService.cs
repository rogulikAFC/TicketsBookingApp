using System.Net;
using System.Net.Mail;

namespace TicketsBookingApp.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _client;
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration
                ?? throw new ArgumentNullException(nameof(configuration));

            _client = new SmtpClient(_configuration["SmtpServer:HostAndPort"])
            {
                Credentials = new NetworkCredential(_configuration["SmtpServer:Username"], _configuration["SmtpServer:Password"]),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage("tickets_booking@app.com", to, subject, $"""
                {body}

                ---
                Tickets booking app, written on ASP.Net core
                """);

            await _client.SendMailAsync(mailMessage);
        }
    }
}
