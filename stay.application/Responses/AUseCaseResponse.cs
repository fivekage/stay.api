namespace stay.application.Responses
{
    public abstract class AUseCaseResponse
    {
        public bool Success { get; }
        public string Message { get; }

        protected AUseCaseResponse(bool success = false, string message = "")
        {
            Success = success;
            Message = message;
        }
    }
}