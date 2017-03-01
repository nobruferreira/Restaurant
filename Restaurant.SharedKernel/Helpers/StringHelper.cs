﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Restaurant.SharedKernel.Helpers
{
    public class StringHelper
    {
        public static string Encrypt(string value)
        {
            MD5 md5 = MD5.Create();      
            byte[] inputBytes = Encoding.ASCII.GetBytes(value);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            return sb.ToString();
        }

        public static string GetTicks()
        {
            return DateTime.Now.Ticks.ToString();
        }
    }
}
