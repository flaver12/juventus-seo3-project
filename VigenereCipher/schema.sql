CREATE DATABASE VigenereCipherDB;

USE VigenereCipherDB;

CREATE TABLE EncryptionRecords (
                                   Id INT PRIMARY KEY IDENTITY(1,1),
                                   EncryptText NVARCHAR(MAX),
                                   DecryptText NVARCHAR(MAX),
    [Key] NVARCHAR(100),
    TimeStamp DATETIME
    );