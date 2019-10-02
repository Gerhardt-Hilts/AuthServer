using System;
using Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("[controller]")]
    [ApiController] 
    public class TestController : ControllerBase
    {
        // GET auth/test
        // basic get method for testing
        [HttpGet("test")]
        public HttpsResponse<string> Test()
        {
            Console.WriteLine("TESTING!");
            return new HttpsResponse<string>(HttpsResponse<string>.ResponseStatus.ResponseStatusCode.Ok, "test success", "success!");
        }
    }
}