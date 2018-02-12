//-----------------------------------------------------------------------
// <copyright file= "DataEncrypt.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/12 星期一 11:26:28
// Modified by:
// Description: 3DES对称加密
//-----------------------------------------------------------------------
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PSU.Utility.System
{
    public class DataEncrypt
    {
        #region Field

        private const string _key = "1c5D3230A9534CC6abc7E108103604Dd";

        private const string _iv = "bc5YTx+RoeQ=";

        private SymmetricAlgorithm _sym = null;

        #endregion


        #region Encrypt

        public DataEncrypt()
        {
            _sym = new TripleDESCryptoServiceProvider();
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString">需要加密的字符串</param>
        /// <returns></returns>
        public string EncryptString(string encryptString)
        {
            _sym.Key = Convert.FromBase64String(_key);
            _sym.IV = Convert.FromBase64String(_iv);
            _sym.Mode = CipherMode.ECB;
            _sym.Padding = PaddingMode.PKCS7;

            ICryptoTransform iCrypt = _sym.CreateEncryptor(_sym.Key, _sym.IV);
            byte[] bytes = Encoding.UTF8.GetBytes(encryptString);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, iCrypt, CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString">需要解密的字符串</param>
        /// <returns></returns>
        public string DecryptString(string decryptString)
        {
            _sym.Key = Convert.FromBase64String("1c5D3230A9534CC6abc7E108103604Dd");
            _sym.IV = Convert.FromBase64String("bc5YTx+RoeQ=");
            _sym.Mode = CipherMode.ECB;
            _sym.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = _sym.CreateDecryptor(_sym.Key, _sym.IV);
            byte[] buffer = Convert.FromBase64String(decryptString);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        #endregion
    }
}
