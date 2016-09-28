using System;
using System.Security.Cryptography;
using System.Text;

namespace Lghui.Framework.Expand
{
    /// <summary>
    /// Des扩展
    /// </summary>
    public static class DesExpand
    {
        private static readonly DESCryptoServiceProvider Des = new DESCryptoServiceProvider()
        {
            Key = "^*lghui*".ToBytes(Encoding.UTF8),
            IV = "*lghui*^".ToBytes(Encoding.UTF8)
        };

        /// <summary>
        /// Des加密
        /// </summary>
        /// <param name="plaintext">待加密字符串</param>
        /// <returns>加密后字符串</returns>
        public static string DesEncrypt(this string plaintext)
        {
            try
            {
                var data = Encoding.UTF8.GetBytes(plaintext);

                var desencrypt = Des.CreateEncryptor();

                var result = desencrypt.TransformFinalBlock(data, 0, data.Length);

                return Convert.ToBase64String(result);
            }
            catch (Exception)
            {
                return plaintext;
            }
        }

        /// <summary>
        /// Des解密
        /// </summary>
        /// <param name="ciphertext">待解密字符串</param>
        /// <returns>解密后字符串</returns>
        public static string DesDecrypt(this string ciphertext)
        {
            try
            {
                var data = Convert.FromBase64String(ciphertext);

                var desencrypt = Des.CreateDecryptor();

                var result = desencrypt.TransformFinalBlock(data, 0, data.Length);

                return Encoding.UTF8.GetString(result);
            }
            catch (Exception)
            {
                return ciphertext;
            }

        }
    }
}
