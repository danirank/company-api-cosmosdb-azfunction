namespace Customer.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }


        public string Address { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }

        public int SalesmanId { get; set; }
        public Salesman Salesman { get; set; }

        
    }
}