﻿using Sandbox.Extensions;
using Sandbox.Interfaces;
using System;
using System.Security.Cryptography;

namespace Sandbox.Models
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveBytesIterationsCounts = 10000;
        private static readonly int SaltSize = 40;

        public string GetSalt(string value)
        {
            if (value.IsValid())
            {
                throw new ArgumentException("Can not generate salt from empty value.");
            }

            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if (value.IsValid())
            {
                throw new ArgumentException("Can not generate hash from empty value.");
            }
            if (salt.IsValid())
            {
                throw new ArgumentException("Can not use an empty salt from hashing value.");
            }

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCounts);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
