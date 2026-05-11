namespace Company.Core.Services;

using System.ComponentModel.DataAnnotations;
using Azure.Core;
using Company.Core.Configurations;
using Company.Core.Interfaces;
using Company.Domain.Dto;
using Company.Domain.Entities;
using Company.Domain.Enums;
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

    public async Task SendEmailAsync(
    StatusType status,
    CustomerEntity customer,
    CancellationToken cancellationToken = default)
    {
        var emailBuilder = new EmailBuilderDto(status)
        {
            CustomerName = customer.Name,
            CustomerAdress = customer.Address,
            CustomerTitle = customer.Title,
            CustomerEmail = customer.Email,
            CustomerPhone = customer.Phone
        };

        var message = new EmailMessage
        {
            To = customer.SalesmanEmail ?? string.Empty,
            From = _resendOptions.FromEmail,
            Subject = emailBuilder.Subject,
            TextBody = emailBuilder.Body
        };

        await _resend.EmailSendAsync(message);
    }
}

