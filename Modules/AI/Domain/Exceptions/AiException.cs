public class AiException : AppException
{
    public AiException(string message)
        : base(message, StatusCodes.Status400BadRequest)
    {
    }
}