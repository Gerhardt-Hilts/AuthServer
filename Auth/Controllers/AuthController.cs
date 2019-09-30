using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Logic;
using Auth.Models;
using Auth.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenLogic _tokenLogicLayer = new TokenLogic("secret");
        
        // user authentication methods are given their own specific method signature, rather than rolling them into the other grant-types
        
        // POST auth/login-user
        [HttpPost("login-user")]
        public HttpsResponse<object> LoginUser(UserAccountCredentials userAccountLoginCredentials)
        {
            var username = userAccountLoginCredentials.Username;
            var password = userAccountLoginCredentials.Password;
            // check for valid username and password
            var userAuthenticated = UserLogic.AuthenticateUser(username, password);
            // respond if bad request
            if (!userAuthenticated)
                return new HttpsResponse<object>(HttpsResponse<object>.ResponseStatus.ResponseStatusCode.BadRequest,
                    "user could not be authenticated", null);
            // get user id
            var user = UserLogic.GetUserByUsername(username);
            // create access token with user id as subject
            var tokens = _tokenLogicLayer.GenerateTokensForUser(user.UserId);
            // return access token in response
            return new HttpsResponse<object>(HttpsResponse<object>.ResponseStatus.ResponseStatusCode.Ok, "user was authenticated", tokens);
        }
        
        public void LogoutUser()
        {
            
        }
        
        public void RefreshUser()
        {

        }

        public void Authentication(string grantType, string scope, string clientId, string clientSecret, string authorizationCode, )
        {
            
        }

        // GET auth/test
        // basic get method for testing
        [HttpGet("test")]
        public HttpsResponse<string> Test()
        {
            Console.WriteLine("TESTING!");
            return new HttpsResponse<string>(HttpsResponse<string>.ResponseStatus.ResponseStatusCode.Ok, "test success", "success!");
        }
        
        // who has the right to access this auth server?
        // catalogue ids
        // what property decides that they should be authorized?
        // OPEN QUESTION
        // what methods should be openly available?
        // what methods should be restricted to authorized users?
        // users should be labeled with a scope to group them by and decide what resources they have access to
        // resource apis should have 
        
        // what methods should be available restricted or unrestricted?
        
        // user_authentication_credentials: guid, username, password, salt
        // user_authorization_information: guid: scopes
        
        
        // loginUser
        // createUser
        // updateUserScopes
        
        // getScopes
        // createScope
        
        
        
        // why send the client id at all?
        
        // do the thing
        // do what thing?
        // login the user
        // what user? what's the password? who are you?
        // username, password, client id
        // check LIST of USERNAME PASSWORD COMBINATIONS
        // check registered clients
        
        // do the thing
        // do what thing?
        // create a user
        // what user?
        // username, password
        // who are you?
        // client id
        
        // what to store?
        // user_authentication_credentials: guid, username, password, salt
        // user_authorized_scopes: guid (of this connection), guid (of user), scope
        //     example: 
        //         guid_of_connection | guid_of_user | guid_of_scope
        //             connection_a | user_a | scope_a
        //             connection_b | user_a | scope_b
        //             connection_c | user_b | scope_a
        // listed_scopes: guid, scope, resources available to scopes
        // list of resources
        
        // list of resources
        // list of users
        // list of clients
        
        // essentials
        //    resources - keep list of available resources
        //    client - keep list of valid clients
        //    users - keep list of users and their credentials
        
        
    }
}