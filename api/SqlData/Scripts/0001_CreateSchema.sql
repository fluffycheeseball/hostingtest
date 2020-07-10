CREATE TABLE UserProfiles (
    id int IDENTITY(1,1) PRIMARY KEY,
    UserName nvarchar(255) NOT NULL,
    CONSTRAINT UserProfile_UserName UNIQUE(UserName), 
    Email nvarchar(255) NOT NULL,
    CONSTRAINT UserProfile_Email UNIQUE(Email),
    --json formatted additional data to allow functionality to be extended without over complicating the schema
    AdditionalData nvarchar(4000)
);