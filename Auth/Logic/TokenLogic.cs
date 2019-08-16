using System;
using System.Collections.Generic;
using JWT.Algorithms;
using JWT.Builder;

namespace Auth.Logic
{
    public class TokenLogic
    {
        public TokenLogic(string secret)
        {
            _secret = secret;
        }
        private readonly string _secret;

        public string GenerateTokensForUser(string userId)
        {
            var subject = userId;
            // create the access token
            var accessToken = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_secret)
                .AddClaim("iat", DateTimeOffset.UtcNow)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds())
                .AddClaim("sub", subject)
                .Build();
            // var refreshToken
            return accessToken;
        }

        public void BlacklistToken()
        {
            // invalidates a token
        }
    }
}