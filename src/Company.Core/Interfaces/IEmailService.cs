using Company.Domain.Dto;
using Company.Domain.Entities;
using Company.Domain.Enums;

namespace Company.Core.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(StatusType status, CustomerEntity customer, CancellationToken cancellationToken = default);
}