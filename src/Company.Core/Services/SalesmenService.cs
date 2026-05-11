using Company.Core.Interfaces;
using Company.Domain.Dto;
using Company.Domain.Entities;
using Company.Domain.Interfaces;

namespace Company.Core.Services;

public class SalesmenService : ISalesmenService
{
    private readonly ISalesmanRepo  _salesmanRepo;

    public SalesmenService(ISalesmanRepo salesmanRepo)
    {
        _salesmanRepo = salesmanRepo;
    }

    public async Task<GetSalemenDto> AddSalesmanAsync(AddSalesmanDto salesman)
    {
        var salesmanEntity = new Salesman(salesman.Name, salesman.Email, salesman.Phone);

        salesmanEntity.Id = Guid.NewGuid().ToString();
        var result  = await _salesmanRepo.AddSalesmanAsync(salesmanEntity);

        if (result is null)
            return new GetSalemenDto { ErrorMessage = "Failed to add salesman." };

        return new GetSalemenDto
        {
            Id = result.Id,
            Name = result.Name,
            Email = result.Email,
            Phone = result.Phone
        };

    }

    public async Task<List<GetSalemenDto>> GetSalesmenAsync()
    {
        var salesmen = await _salesmanRepo.GetSalesmenAsync();
        
        return salesmen.Select(s => new GetSalemenDto
        {
            Id = s.Id,
            Name = s.Name,
            Email = s.Email,
            Phone = s.Phone
        }).ToList();
    
    }
    

    public async Task<GetSalemenDto> GetSalesmanByEmailAsync(string salesmanEmail)
    {
        var salesman = await _salesmanRepo.GetSalesmanByEmailAsync(salesmanEmail);
        
        if (salesman is null)
            return new GetSalemenDto { ErrorMessage = "Salesman not found." };

        return new GetSalemenDto
        {
            Id = salesman.Id,
            Name = salesman.Name,
            Email = salesman.Email,
            Phone = salesman.Phone
        };
    }
}