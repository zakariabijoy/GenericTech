using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace Ordering.Infrastructure.Mail;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly EmailSettings _emailSettings;

    public EmailService(ILogger<EmailService> logger, IOptions<EmailSettings> emailSettings)
    {
        _logger = logger;
        _emailSettings = emailSettings.Value;
    }

    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var from = new EmailAddress(_emailSettings.FromAddress,_emailSettings.FromName);
        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(msg);
        _logger.LogInformation("Email Sent");

        if(response.StatusCode == HttpStatusCode.Accepted || response.StatusCode ==  HttpStatusCode.OK)
            return true;

        _logger.LogError("Email sending Failed");
        return false;   
    }
}
