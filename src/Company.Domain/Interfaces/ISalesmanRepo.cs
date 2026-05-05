using Company.Domain.Entities;

namespace Company.Domain.Interfaces;

public interface ISalesmanRepo
{
    Task<Salesman> GetSalesmanByIdAsync(string id);
    Task<Salesman> AddSalesmanAsync(Salesman salesman);
    Task<List<Salesman>> GetSalesmenAsync();
}