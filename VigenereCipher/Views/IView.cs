using VigenereCipherApp.Models;

namespace VigenereCipherApp.Views;

public interface IView
{
    void DisplayMenu();
    string GetUserInput(string prompt);
    void DisplayOutput(string output);
    void DisplayRecords(List<EncryptionRecord> records);
}