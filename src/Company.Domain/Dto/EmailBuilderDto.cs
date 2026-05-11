using System.Reflection;
using Company.Domain.Entities;
using Company.Domain.Enums;

namespace Company.Domain.Dto;

public class EmailBuilderDto
{
    public StatusType Type { get; set; }

    public string Subject => GetSubject();

    public string CustomerName { get; set; } = null!;

    public string CustomerTitle { get; set; } = null!;
    public string CustomerAdress { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;

    public string Body => EmailText();

    public EmailBuilderDto(StatusType type)
    {
        Type = type;
    }

    private string GetSubject()
    {
        return Type switch
        {
            StatusType.Created => "New Customer Created",
            StatusType.Updated => "Customer Updated",
            StatusType.Deleted => "Customer Deleted",
            _ => "Unknown"
        };
    }

    private string EmailText()
    {

        var baseBody = $"Customer Title: {CustomerTitle}\n" +
                $"Customer Address: {CustomerAdress}\n" +
                $"Customer Name: {CustomerName}\n" +
                $"Customer Email: {CustomerEmail}\n" +
                $"Customer Phone: {CustomerPhone}";
                
        return Type switch
        {
            StatusType.Created =>
                $"New customer has been created!\n\n" + baseBody,
                

            StatusType.Updated =>
                $"Customer has been updated!\n\n" + baseBody,

            StatusType.Deleted =>
                $"Customer {CustomerName} has been removed!",

            _ => "Unknown"
        };
    }
}