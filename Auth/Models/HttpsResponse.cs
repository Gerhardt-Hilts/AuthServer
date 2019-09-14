using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class HttpsResponse<TDataType>
    {
        // Status Sub Class
        public class ResponseStatus
        {
            // Status Code Enum
            public enum ResponseStatusCode
            {
                Ok = 200,
                BadRequest = 400,
                Unauthorized = 401,
                NotFound = 404
            }

            // dictionary tying status codes enum to strings for ease
            private readonly Dictionary<ResponseStatusCode, string> _statusTypes =
                new Dictionary<ResponseStatusCode, string>
                {
                    {ResponseStatusCode.Ok, "success"},
                    {ResponseStatusCode.BadRequest, "bad request"},
                    {ResponseStatusCode.Unauthorized, "unauthorized"},
                    {ResponseStatusCode.NotFound, "not found"}
                };

            // Properties
            public bool Error;
            public ResponseStatusCode Code;
            public string Type;
            public string Message;

            public ResponseStatus(ResponseStatusCode code, string message)
            {
                Error = code == ResponseStatusCode.Ok;
                Code = code;
                Type = _statusTypes[code];
                Message = message;
            }

        }

        public ResponseStatus Status;
        public TDataType Data;

        // constructor
        public HttpsResponse(ResponseStatus.ResponseStatusCode code, string message, TDataType dataPayload)
        {
            Status = new ResponseStatus(code, message);
            Data = dataPayload;
        }
    }
}