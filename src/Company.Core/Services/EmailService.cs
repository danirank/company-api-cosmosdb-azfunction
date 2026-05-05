namespace Company.Core.Services;

using Company.Core.Configurations;
using Company.Core.Interfaces;
using Company.Domain.Dto;
using Microsoft.Extensions.Options;
using Resend;

public class EmailService : IEmailService
{

    private readonly ResendOptions _resendOptions;
    private readonly IResend _resend;

    public EmailService(IOptions<ResendOptions> resendOptions, IResend resend)
    {
        _resendOptions = resendOptions.Value;
        _resend = resend;
    }

    public Task SendEmailAsync(EmailBuilderDto emailBuilder)
    {
        var text = emailBuilder.EmailText();

       var message = new EmailMessage
        {
            To = emailBuilder.ToEmail,
            From = _resendOptions.FromEmail,
            Subject = emailBuilder.Subject,
            TextBody = text
        };

        message.To.Add(emailBuilder.ToEmail);

        return _resend.EmailSendAsync(message);
    }
}

