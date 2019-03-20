using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ManagePatient.Utils
{
    public static class SecurityHelper
    {
        private static byte[] KeyBytes = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Key"]);
        private static byte[] VectorBytes = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Vector"]);
        public static string Encrypt(this string valueToEncrypt)
        {
            byte[] encrypted;
            using (RijndaelManaged cipher = new RijndaelManaged())
            {
                cipher.Mode = CipherMode.CBC;
                using (ICryptoTransform encryptor = cipher.CreateEncryptor(KeyBytes, VectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            var valueBytes = Encoding.ASCII.GetBytes(valueToEncrypt);
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }

            }
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(this string valueToDecrypt)
        {
            if (string.IsNullOrEmpty(valueToDecrypt))
                return valueToDecrypt;
            byte[] valueBytes = Convert.FromBase64String(valueToDecrypt);

            byte[] decrypted;
            int decryptedByteCount = 0;

            using (RijndaelManaged cipher = new RijndaelManaged())
            {
                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform decryptor = cipher.CreateDecryptor(KeyBytes, VectorBytes))
                {
                    using (MemoryStream from = new MemoryStream(valueBytes))
                    {
                        using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                        {
                            decrypted = new byte[valueBytes.Length];
                            decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                        }
                    }
                }

                cipher.Clear();
            }
            return Encoding.ASCII.GetString(decrypted, 0, decryptedByteCount);
        }

    }
}