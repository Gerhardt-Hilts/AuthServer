using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Layers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // POST auth/sign-up
        [HttpGet("sign-up")]
        public void SignUp()
        {
            // TODO: fill in method stub
            // 
        }

        // POST auth/login
        [HttpPost("log-in")]
        public void LogIn()
        {
            // TODO: fill in method stub
            // input validation
            // serialize request body
            // get username, password
            // generate JWT
            // create session
            // translate to opaque token and save
            // return opaque token
        }

        // POST auth/sign-out
        [HttpGet("log-out")]
        public void LogOut()
        {
            // TODO: fill in method stub
            // remove opaque token from saved valid tokens
        }
    }
}