using System.Data.SqlClient;
using VigenereCipherApp.Models;

namespace VigenereCipherApp.Services;

    public class MSSQLDatabaseService : IDatabaseService
    {
        private readonly string _connectionString;

        public MSSQLDatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveRecord(EncryptionRecord record)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO EncryptionRecords (EncryptText, DecryptText, [Key], TimeStamp) VALUES (@EncryptText, @DecryptText, @Key, @TimeStamp)", 
                    connection);
                command.Parameters.AddWithValue("@EncryptText", record.EncryptText);
                command.Parameters.AddWithValue("@DecryptText", record.DecryptText);
                command.Parameters.AddWithValue("@Key", record.Key);
                command.Parameters.AddWithValue("@TimeStamp", record.TimeStamp);

                command.ExecuteNonQuery();
            }
        }

        public List<EncryptionRecord> GetRecords()
        {
            var records = new List<EncryptionRecord>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM EncryptionRecords", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var record = new EncryptionRecord(
                        reader["EncryptText"].ToString(),
                        reader["DecryptText"].ToString(),
                        reader["Key"].ToString())
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        TimeStamp = Convert.ToDateTime(reader["TimeStamp"])
                    };

                    records.Add(record);
                }
            }

            return records;
        }
    }