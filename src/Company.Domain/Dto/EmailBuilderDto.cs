using Company.Domain.Entities;
using Company.Domain.Enums;

namespace Company.Domain.Dto;

public class EmailBuilderDto
{
    

    public OutboxType Type { get; set; }
    public string ToEmail { get; set; } = null!;
    public string Subject { get; set; } = "New Customer Assigned";
    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;

    public string CreatedBody => $"You have been assigned a new customer!\n\nCustomer Name: {CustomerName}\nCustomer Email: {CustomerEmail}\nCustomer Phone: {CustomerPhone}";

    public string UpdatedBody => $"Your customer information has been updated!\n\nCustomer Name: {CustomerName}\nCustomer Email: {CustomerEmail}\nCustomer Phone: {CustomerPhone}";

    public string DeletedBody => $"Customer {CustomerName} has been removed!";


    public EmailBuilderDto(OutboxType type, string toEmail, string customerName, string customerEmail, string customerPhone)
    {
        Type = type;
        ToEmail = toEmail;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;
    }
    

    public string EmailText()
    {
        if (Type == OutboxType.Created)
            return $"To: {ToEmail}\n\n{CreatedBody}";

        if (Type == OutboxType.Updated)
            return $"To: {ToEmail}\n\n{UpdatedBody}";

        if (Type == OutboxType.Deleted)
            return $"To: {ToEmail}\n\n{DeletedBody}";

        return string.Empty;
    }
}