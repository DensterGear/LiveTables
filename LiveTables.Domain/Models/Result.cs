namespace LiveTables.Domain.Models
{
    public class Result
    {
        public bool IsError { get; set; }
        public bool IsSuccess => !IsError;
        public DomainError ErrorValue { get; set; }
    }
    
    public class Result<TResult> : Result
    {
        public TResult ResultValue { get; set; }
    }
}