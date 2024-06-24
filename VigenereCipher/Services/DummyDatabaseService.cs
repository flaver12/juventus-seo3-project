using VigenereCipherApp.Models;

namespace VigenereCipherApp.Services;

public class DummyDatabaseService : IDatabaseService
{
    private readonly List<EncryptionRecord> _records = new List<EncryptionRecord>();

    public void SaveRecord(EncryptionRecord record)
    {
        _records.Add(record);
    }

    public List<EncryptionRecord> GetRecords()
    {
        return _records;
    }
}