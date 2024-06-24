using VigenereCipherApp.Models;
using VigenereCipherApp.Services;
using VigenereCipherApp.Views;

namespace VigenereCipherApp.Controllers;

public class MainController
{
    private readonly IEncryptionService _encryptionService;
    private readonly IView _view;
    private readonly IDatabaseService _databaseService;

    public MainController(IEncryptionService encryptionService, IView view, IDatabaseService databaseService)
    {
        _encryptionService = encryptionService;
        _view = view;
        _databaseService = databaseService;
    }

    public void Run()
    {
        while (true)
        {
            var records = _databaseService.GetRecords();
            _view.DisplayRecords(records);
            
            _view.DisplayMenu();
            string choice = _view.GetUserInput("Choose an option: ");

            switch (choice)
            {
                case "1":
                    string plainText = _view.GetUserInput("Enter text to encrypt: ");
                    string encryptKey = _view.GetUserInput("Enter encryption key: ");
                    string encryptedText = _encryptionService.Encrypt(plainText, encryptKey);
                    _databaseService.SaveRecord(new EncryptionRecord(encryptedText, plainText, encryptKey));
                    _view.DisplayOutput($"Encrypted Text: {encryptedText}");
                    break;

                case "2":
                    string cipherText = _view.GetUserInput("Enter text to decrypt: ");
                    string decryptKey = _view.GetUserInput("Enter decryption key: ");
                    string decryptedText = _encryptionService.Decrypt(cipherText, decryptKey);
                    _view.DisplayOutput($"Decrypted Text: {decryptedText}");
                    break;

                case "3":
                    return;

                default:
                    _view.DisplayOutput("Invalid option. Please try again.");
                    break;
            }
        }
    }
}