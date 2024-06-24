namespace VigenereCipherApp.Services;

public class EncryptionService : IEncryptionService
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789,.:\"!?";

    public string Encrypt(string plainText, string key)
    {
        return ProcessText(plainText, key, true);
    }

    public string Decrypt(string cipherText, string key)
    {
        return ProcessText(cipherText, key, false);
    }

    private string ProcessText(string text, string key, bool encrypt)
    {
        int N = Alphabet.Length;
        char[] result = new char[text.Length];
        key = ExtendKey(key, text.Length);

        for (int i = 0; i < text.Length; i++)
        {
            int textIndex = Alphabet.IndexOf(text[i]);
            int keyIndex = Alphabet.IndexOf(key[i]);

            if (textIndex == -1 || keyIndex == -1)
            {
                result[i] = text[i]; // Leave characters not in the alphabet unchanged
            }
            else
            {
                int newIndex = encrypt ? (textIndex + keyIndex) % N : (textIndex - keyIndex + N) % N;
                result[i] = Alphabet[newIndex];
            }
        }
        return new string(result);
    }

    private string ExtendKey(string key, int length)
    {
        while (key.Length < length)
        {
            key += key;
        }
        return key.Substring(0, length);
    }
}