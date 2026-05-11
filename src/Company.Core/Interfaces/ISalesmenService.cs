using Company.Domain.Dto;

namespace Company.Core.Interfaces;


public interface ISalesmenService
{
     Task<List<GetSalemenDto>> GetSalesmenAsync();

     Task<GetSalemenDto> GetSalesmanByEmailAsync(string salesmanEmail);

     Task<GetSalemenDto> AddSalesmanAsync(AddSalesmanDto salesman);


}