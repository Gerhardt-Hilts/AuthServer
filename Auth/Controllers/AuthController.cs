using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Logic;
using Auth.Models;
using Auth.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthLogic _authLogicLayer = new AuthLogic("secret");
        
        // POST auth/login-user
        [HttpPost("login-user")]
        public Response<string> LoginUser(UserCredentials userLoginCredentials)
        {
            var username = userLoginCredentials.Username;
            var password = userLoginCredentials.Password;
            // check for valid username and password
            var userAuthenticated = _authLogicLayer.AuthenticateUser(username, password);
            // respond if bad request
            if (!userAuthenticated)
                return new Response<string>(Response<string>.ResponseStatus.ResponseStatusCode.BadRequest,
                    "user could not be authenticated", null);
            // get user id
            var userId = _authLogicLayer.GetUserIdByUsername(username);
            // create access token with user id as subject
            var accessToken = _authLogicLayer.GenerateTokensForUser(userId);
            // return access token in response
            return new Response<string>(Response<string>.ResponseStatus.ResponseStatusCode.Ok, "user was authenticated", accessToken);
        }
        
        // GET auth/test
        // basic get method for testing
        [HttpGet("test")]
        public Response<string> Test()
        {
            Console.WriteLine("TESTING!");
            return new Response<string>(Response<string>.ResponseStatus.ResponseStatusCode.Ok, "test success", "success!");
        }
    }
}