namespace Customer.Domain.Dto
{
    public class AddCustomerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int SalesmanId { get; set; }
    }
}