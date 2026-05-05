using Company.Domain.Dto;

namespace Company.Core.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(EmailBuilderDto emailBuilder);
}