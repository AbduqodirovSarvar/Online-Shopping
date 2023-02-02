﻿using Shop.App.Abstracts;
using System.Security.Cryptography;
using System.Text;

namespace Shop.Infrastructue.Providers
{
    public class GetPasswordHash : IGetPasswordHash
    {
        public string GetHash(string value)
        {
            const int keySize = 64;
            const int iterations = 350000;

            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(value),
                new byte[0],
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
    }
}
