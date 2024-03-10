namespace CashControl.API.Models
{
    public class ServiceResponseModel
    {
        public object? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
    }
}
