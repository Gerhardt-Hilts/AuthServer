using System.Reflection.Metadata.Ecma335;

namespace Auth.Models
{
    public class DatabaseResponse
    {
        public StatusCode Code;
        public string Message;

        public DatabaseResponse(StatusCode code, string message)
        {
            Code = code;
            Message = message;
        }
    }

    public class DatabaseResponse<TDataType>
    {
        public StatusCode Code;
        public string Message;
        public TDataType Payload;
        
        public DatabaseResponse(StatusCode code, string message, TDataType payload)
        {
            Code = code;
            Message = message;
            Payload = payload;
        }
    }

}