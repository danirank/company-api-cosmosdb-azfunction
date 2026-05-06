namespace Company.Core.Services;

using System.ComponentModel.DataAnnotations;
using Company.Core.Configurations;
using Company.Core.Interfaces;
using Company.Domain.Dto;
using Company.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Resend;

public class EmailService : IEmailService
{

    private readonly ResendOptions _resendOptions;
    private readonly IResend _resend;

    private readonly ICustomerRepo _customerRepo;
    public EmailService(IOptions<ResendOptions> resendOptions, IResend resend, ICustomerRepo customerRepo)
    {
        _resendOptions = resendOptions.Value;
        _resend = resend;
        _customerRepo = customerRepo;
    }

    public async Task SendEmailAsync(OutboxDto outbox, CancellationToken cancellationToken = default)
    {

        var customer = await _customerRepo.GetCustomerByIdAsync(outbox.CustomerId);

        if (customer is null)
        {
            throw new ValidationException($"Customer with ID {outbox.CustomerId} not found.");
        }

        var emailBuilder = new EmailBuilderDto(
            outbox.EventType,
            customer.Email,
            customer.Name,
            customer.Email,
            customer.Phone
            );

        var message = new EmailMessage
        {
            To = customer.SalesmanEmail ?? string.Empty,
            From = _resendOptions.FromEmail,
            Subject = emailBuilder.Subject,
            TextBody = emailBuilder.EmailText()
        };


        await _resend.EmailSendAsync(message);
    }
}

