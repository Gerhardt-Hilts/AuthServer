using System;
using Auth.Models;
using Auth.Util;
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

        public AuthTokens GenerateTokensForUser(string userId)
        {
            // create an ids for the tokens
            var accessTokenId = Guid.NewGuid().ToString();
            var refreshTokenId = Guid.NewGuid().ToString();
            
            // create the tokens
            var accessToken = CreateAccessToken(userId, accessTokenId);
            var refreshToken = CreateRefreshToken();
            
            // record the tokens
            RecordAccessToken(accessTokenId, userId, accessToken);
            RecordRefreshToken(refreshTokenId, userId, refreshToken);
            return new AuthTokens(accessToken, refreshToken);
        }

        public string CreateAccessToken(string userId, string tokenId)
        {
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_secret)
                .AddClaim("iat", DateTimeOffset.UtcNow)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds())
                .AddClaim("sub", userId)
                .AddClaim("jti", tokenId)
                .Build();
        }

        public string CreateRefreshToken()
        {
            return Crypto.GetUniqueKey(32);
        }

        public void RecordAccessToken(string accessTokenId, string userId, string accessToken)
        {
            
        }

        public void RecordRefreshToken(string refreshTokenId, string userId, string refreshToken)
        {
            
        }

        // public void RevokeAccessToken()
        // {
        //     // invalidates a token
        //     
        //     // this method sends a blacklist of tokens that should not be allowed to resources within that tokens scope
        //     // this method should only be used to immediately revoke a tokens access, but can also be used if you wish
        //     //     to issue a larger time frame for the access token
        //     
        //     // using the blacklist refresh token is preferable as it reduces the amount of work needed on the resource
        //     //     side, which would need to have it's own blacklist that could be updated at a moments notice from
        //     //     this server
        // }

        public void RevokeRefreshToken()
        {
            
        }
        
    }
}