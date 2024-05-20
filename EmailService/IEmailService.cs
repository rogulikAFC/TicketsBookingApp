using System.Net.Mail;

namespace TicketsBookingApp.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
