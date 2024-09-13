using System.Net;
using System.Net.Mail;
using Application.Contracts;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace Infrastructure.Services;
public class EmailSender : IEmail
{
    private readonly Email _emailSettings;
    private readonly ILogger<EmailSender> _logger;
    public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
    {
        _emailSettings = configuration.GetSection("EmailSettings").Get<Email>()!;
        _logger = logger;
    }
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        try
        {
            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password)
            };

            var mailMessage = new MailMessage(
                from: _emailSettings.Username,
                to: email,
                subject,
                body: message
            );
            _logger.LogInformation("Attempting to send email to {email} using SMTP server {Host}:{Port}", email, _emailSettings.Host, _emailSettings.Port);
            await client.SendMailAsync(mailMessage);
            _logger.LogInformation("Email sent successfully to {email}", email);
        }
        catch(SmtpException error)
        {
            _logger.LogError("SMTP error occurred while sending email to {email}. Error: {message}", email, error.Message);
            throw;
        }
        catch (Exception error)
        {
            _logger.LogError("An error occurred while sending email to {email}. Error: {message}", email, error.Message);
            throw;
        }
    }
}
