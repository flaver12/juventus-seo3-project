using VigenereCipherApp.Controllers;
using VigenereCipherApp.Services;
using VigenereCipherApp.Views;

namespace VigenereCipherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost,1433;Database=VigenereCipherDB;User Id=sa;Password=YourStrong(!)Password;"; // Update with your actual connection string
            IEncryptionService encryptionService = new EncryptionService();
            IView view = new ConsoleView();
            IDatabaseService databaseService = new MSSQLDatabaseService(connectionString);
            MainController controller = new MainController(encryptionService, view, databaseService);
            controller.Run();
        }
    }
}
