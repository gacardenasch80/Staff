using Microsoft.AspNetCore.Http;
using System.Text;
using System;
using System.Security.Cryptography;

namespace CandidatesMS.Helpers
{
    public interface ICryptoHelper
    {
        string EncodeSHA256(string name, string type, double weight);
    }

    public class CryptoHelper : ICryptoHelper
    {
        public string EncodeSHA256(string name, string type, double weight)
        {
            string stringBase = name + type + weight.ToString();

            // convert to bytes using UTF-8 encoding
            byte[] tokenBytes = Encoding.UTF8.GetBytes(stringBase);

            // convert those bytes to a hexadecimal string
            string tokenBytesHex = BitConverter.ToString(tokenBytes).Replace("-", "");

            // convert that string back to bytes (UTF-8 used here since that is the default on PHP, but ASCII will work too)
            byte[] tokenBytesHexBytes = Encoding.UTF8.GetBytes(stringBase);

            // hash those bytes
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(tokenBytesHexBytes);

                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
