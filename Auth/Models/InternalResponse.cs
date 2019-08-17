namespace Auth.Models
{
    public enum InternalStatusCode
    {
        Ok,
        Empty,
        Failed
    }
        
    public class InternalResponse<TDataPayload> : InternalResponse
    {
        public TDataPayload Payload;
        
        public InternalResponse(InternalStatusCode code, string message, TDataPayload payload) : base(code, message)
        {
            Payload = payload;
        }
    }

    public class InternalResponse
    {
        public InternalStatusCode Code;
        public string Message;
        
        public InternalResponse(InternalStatusCode code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}