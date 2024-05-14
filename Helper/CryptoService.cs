using LeagueOfDraven.Helper.Interface;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;
using System.Text;

namespace LeagueOfDraven.Helper
{
    public class CryptoService : ICryptoService
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string key = "*P#rt@!*";
        private const string key256 = "S2lGUVQxSlVRQ0ZEUVZKU1JWSkFJUT09LE1USXpORFUyTnlJcUlWQlBVbFJBSVVOQlVsSkZVa0FoSWpjMk5UUXpNakU9";
        private readonly int keySize = 256;

        public CryptoService(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        public string EncryptDataProtection(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);
            return protector.Protect(input);
        }

        public string DecryptDataProtection(string cipherText)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);
            return protector.Unprotect(cipherText);
        }

        public string Decrypt(string encryptedText)
        {
            try
            {
                if (String.IsNullOrEmpty(encryptedText))
                    return string.Empty;

                RijndaelManaged aesEncryption = new RijndaelManaged();
                aesEncryption.KeySize = keySize;
                aesEncryption.BlockSize = 128;
                aesEncryption.Mode = CipherMode.CBC;
                aesEncryption.Padding = PaddingMode.PKCS7;
                aesEncryption.GenerateIV();
                aesEncryption.GenerateKey();
                aesEncryption.IV = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(key256)).Split(',')[0]);
                aesEncryption.Key = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(key256)).Split(',')[1]);
                ICryptoTransform decrypto = aesEncryption.CreateDecryptor();
                byte[] encryptedBytes = Convert.FromBase64CharArray(encryptedText.ToCharArray(), 0, encryptedText.Length);
                return ASCIIEncoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string Encrypt(string plainStr)
        {
            try
            {
                RijndaelManaged aesEncryption = new RijndaelManaged();
                aesEncryption.KeySize = keySize;
                aesEncryption.BlockSize = 128;
                aesEncryption.Mode = CipherMode.CBC;
                aesEncryption.Padding = PaddingMode.PKCS7;
                aesEncryption.IV = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(key256)).Split(',')[0]);
                aesEncryption.Key = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(key256)).Split(',')[1]);
                byte[] plainText = ASCIIEncoding.UTF8.GetBytes(plainStr);
                ICryptoTransform crypto = aesEncryption.CreateEncryptor();
                // The result of the encryption and decryption            
                byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
                return Convert.ToBase64String(cipherText);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}
