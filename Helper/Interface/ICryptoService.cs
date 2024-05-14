namespace LeagueOfDraven.Helper.Interface
{
    public interface ICryptoService
    {
        string EncryptDataProtection(string input);
        string DecryptDataProtection(string cipherText);
        string Decrypt(string encryptedText);
        string Encrypt(string plainStr);
    }
}
