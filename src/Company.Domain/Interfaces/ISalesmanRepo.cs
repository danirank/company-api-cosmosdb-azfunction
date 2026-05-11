using Company.Domain.Entities;

namespace Company.Domain.Interfaces;

public interface ISalesmanRepo
{
    Task<Salesman> GetSalesmanByIdAsync(string id);

    Task<List<Salesman>> GetSalesmenAsync();
    Task<Salesman?> GetSalesmanByEmailAsync(string email);   
    Task<Salesman> AddSalesmanAsync(Salesman salesman);
    
}