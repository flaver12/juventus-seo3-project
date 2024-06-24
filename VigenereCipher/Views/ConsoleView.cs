using VigenereCipherApp.Models;

namespace VigenereCipherApp.Views;

public class ConsoleView : IView
{
    public void DisplayMenu()
    {
        Console.WriteLine("Vigenere Cipher");
        Console.WriteLine("1. Encrypt Text");
        Console.WriteLine("2. Decrypt Text");
        Console.WriteLine("3. Exit");
    }
    
    public void DisplayRecords(List<EncryptionRecord> records)
    {
        Console.WriteLine("Stored Records:");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("| Encrypted Text | Decrypted Text | Decryption Key | Timestamp |");
        Console.WriteLine("-------------------------------------------------");
        foreach (var record in records)
        {
            Console.WriteLine($"| {record.EncryptText} | {record.DecryptText} | {record.Key} | {record.TimeStamp} |");
        }
        Console.WriteLine("-------------------------------------------------");
    }

    public string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public void DisplayOutput(string output)
    {
        Console.WriteLine(output);
    }
}