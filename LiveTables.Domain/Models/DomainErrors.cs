namespace LiveTables.Domain.Models
{
    public class DomainError
    {
        protected DomainError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }
    }
    
    public class ValidationError : DomainError
    {
        public ValidationError(string errorMessage) : base(errorMessage)
        {
        }
    }
    
    public class SystemError : DomainError
    {
        public SystemError(string errorMessage) : base(errorMessage)
        {
        }
    }
    
    public class SourceError : DomainError
    {
        public SourceError(string errorMessage) : base(errorMessage)
        {
        }
    }
}