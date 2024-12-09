namespace Domain.Shared.ExceptionShared
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : 
            base(message: Constants.ErrorNotFound)
        { 
        }

        public NotFoundException() : base(message: Constants.ErrorNotFound)
        {
            
        }
    }
}
