namespace CashControl.API.Exceptions
{
    public class NotFoundBankStatementException : Exception
    {
        public NotFoundBankStatementException(string? message) : base(message) { }
    }
}
