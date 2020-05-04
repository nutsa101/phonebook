namespace PhoneBook.Core.Models
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(string message)
        {
            Message = message;
        }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
