namespace Company.Domain.Dto;

public class EmailBuilderDto
{
    public string ToEmail { get; set; } = null!;
    public string Subject { get; set; } = "New Customer Assigned";
    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;

    public string Body => $"You have been assigned a new customer!\n\nCustomer Name: {CustomerName}\nCustomer Email: {CustomerEmail}\nCustomer Phone: {CustomerPhone}";



    public string EmailText()
    {
        return $"To: {ToEmail}\n\n{Body}";
    }
}