namespace VigenereCipherApp.Models;

public class EncryptionRecord
{
    public int Id { get; set; }
    public string EncryptText { get; set; }
    public string DecryptText { get; set; }
    public string Key { get; set; }
    public DateTime TimeStamp { get; set; }

    public EncryptionRecord(string encryptText, string decryptText, string key)
    {
        EncryptText = encryptText;
        DecryptText = decryptText;
        Key = key;
        TimeStamp = DateTime.Now;
    }
}