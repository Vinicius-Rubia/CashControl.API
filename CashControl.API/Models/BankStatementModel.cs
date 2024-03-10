namespace CashControl.API.Models
{
    public class BankStatementModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTransaction { get; set; }
        public decimal Amount { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
