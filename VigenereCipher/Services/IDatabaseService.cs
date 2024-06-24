using VigenereCipherApp.Models;

namespace VigenereCipherApp.Services;

public interface IDatabaseService
{
    void SaveRecord(EncryptionRecord record);
    List<EncryptionRecord> GetRecords();
}