using System;
using System.Security.Cryptography;

namespace Auth.Util
{
    public static class Crypto
    {
        // taken from https://stackoverflow.com/a/31959204
        // comments below that are not specified otherwise were taken from the snippet
        internal static string GetUniqueKey(int size)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                
            using (var crypto = new RNGCryptoServiceProvider())
            {
                var data = new byte[size];
        
                // If chars.Length isn't a power of 2 then there is a bias if
                // we simply use the modulus operator. The first characters of
                // chars will be more probable than the last ones.
        
                // buffer used if we encounter an unusable random byte. We will
                // regenerate it in this buffer
                byte[] smallBuffer = null;
        
                // Maximum random number that can be used without introducing a
                // bias
                var maxRandom = byte.MaxValue - ((byte.MaxValue + 1) % chars.Length);
        
                crypto.GetBytes(data);
        
                var result = new char[size];
        
                for (var i = 0; i < size; i++)
                {
                    var v = data[i];
        
                    while (v > maxRandom)
                    {
                        if (smallBuffer == null)
                        {
                            smallBuffer = new byte[1];
                        }
        
                        crypto.GetBytes(smallBuffer);
                        v = smallBuffer[0];
                    }
        
                    result[i] = chars[v % chars.Length];
                }
        
                return new string(result);
            }
        }

        // TODO: review the methods below
        // I took this from here
        //     https://medium.com/@mehanix/lets-talk-security-salted-password-hashing-in-c-5460be5c3aae
        //     I don't exactly trust the author's judgement, as a self-titled
        //     'high-school student, programming enthusiast'
        //     the use of Rfc2989 rather than some amateur hashing function,
        //     as well as secure 'Randomness,' using RNGCryptoServiceProvider does seem correct
        // I additionally consulted this article
        //     https://crackstation.net/hashing-security.htm
        // Which has a link at the bottom saying 'Article written by Defuse Security'
        // Which links here
        //     https://defuse.ca/
        //     https://defuse.ca/about.htm
        // Run by a 'Taylor Hornby'
        //     A well respected member of the security community, according to my search results
        //     Involved in:
        //     ZCash which was created by Electric Coin Co, where he is employed
        //     A speaker at Black Hat USA 2016
        //     And of course runs Defuse Security, which the home of many well crafted security tools
        
        internal static byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            var hash = pbkdf2.GetBytes(20);
            var hashBytes = new byte[36];
            
            Array.Copy(salt, 0, hashBytes, 0, 24);
            Array.Copy(hash, 0, hashBytes, 24, 20);

            return hashBytes;
        }

        internal static byte[] CreateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[24]);
            return salt;
        }

        internal static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = a.Length ^ b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }
        
    }
}