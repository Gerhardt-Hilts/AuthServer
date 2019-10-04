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
            _accessTokenDurationValid = Time.HoursToMilliseconds(2);
            _refreshTokenDurationValid = Time.DaysToMilliseconds(2);
        }

        private readonly string _secret;
        private readonly long _accessTokenDurationValid;
        private readonly long _refreshTokenDurationValid;
        private const int RefreshTokenLength = 32;

        public AuthTokens GenerateTokensForUserLogin(string userId, string scopeId, string clientId)
        {
            // set times for tokens
            var now = Time.CurrentTime();
            var issuedAt = now;
            var accessTokenExpiresAt = now + _accessTokenDurationValid;
            var refreshTokenExpiresAt = now + _refreshTokenDurationValid;

            // create the tokens
            var accessToken = CreateAccessToken(userId, scopeId, clientId, issuedAt, accessTokenExpiresAt);
            var refreshToken = CreateRefreshToken(userId, scopeId, clientId, issuedAt, refreshTokenExpiresAt);
            
            // record the tokens
            RecordAccessToken(accessToken);
            RecordRefreshToken(refreshToken);
            return new AuthTokens(accessToken, refreshToken);
        }

        public AuthTokens GenerateTokensForRefreshToken()
        {
            // 
        }

        // These two methods `CreateAccessToken` and `CreateRefreshToken` may seem redundant with the constructor now,
        //     but will allow for different types of tokens later; JWT, Bearer. I believe all token related procedures,
        //     should originate from this class, and logical operations that occur on the tokens themselves should not
        //     be kept within the classes themselves
        // To put this simply, the classes for an object, and the operations on that object should be kept separate.
        //     This helps prevent entropic state changes from causing an operation to fail, and helps prevent bugs when
        //     making additions to the codebase.
        public AccessToken CreateAccessToken(string userId, string scopeId, string clientId, long issuedAt, long expiresAt)
        {
            var tokenId = Guid.NewGuid().ToString();
            var literalToken = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_secret)
                .AddClaim("jti", tokenId)
                .AddClaim("iat", issuedAt)
                .AddClaim("exp", expiresAt)
                .AddClaim("user", userId)
                .AddClaim("scope", scopeId)
                .AddClaim("client", clientId)
                .Build();
            
            return new AccessToken(tokenId, literalToken, userId, clientId, scopeId, issuedAt, expiresAt);
        }

        public RefreshToken CreateRefreshToken(string userId, string scopeId, string clientId, long issuedAt, long expiresAt)
        {
            var tokenId = Guid.NewGuid().ToString();
            var literalToken = Crypto.GetUniqueKey(RefreshTokenLength);
            
            return new RefreshToken(tokenId, literalToken, userId, clientId, scopeId, issuedAt, expiresAt);
        }

        public void RecordAccessToken(AccessToken accessToken)
        {
            
        }

        public void RecordRefreshToken(RefreshToken refreshToken)
        {
            
        }

        // Blacklist tokens
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

        public bool ValidateAccessToken(AccessToken accessToken)
        {
            // Use Jwt library to create new signature and compare it against newly signed claims
            // return bool determining validity
            return false;
        }

        public bool ValidateRefreshToken(RefreshToken refreshToken)
        {
            // Confirm it has not been blacklisted
            // Confirm it has not been invalidated
            // Confirm it is still within the valid use time
            // return bool determining validity
            
            // Think of invalidating a token as a graceful way of terminating a tokens lifespan, while blacklisting is a
            //     way of listing the token as suspicious
            return false;
        }
    }
}