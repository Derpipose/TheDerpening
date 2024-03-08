CREATE TABLE Todos (
    Id int NOT NULL,
    Title nvarchar(90) NOT NULL,
    IsTaskCompleted bit NOT NULL
);

CREATE TABLE Players (
    Id int NOT NULL,
    Name nvarchar(60) NOT NULL,
    Keyword nvarchar(60) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE Characters (
    Id int NOT NULL,
    PlayerId int NOT NULL,
    CharacterName nvarchar(90) NOT NULL,
    Strength int,
    Dexterity int,
    Constitution int,
    Intelligence int,
    Wisdom int, 
    Charisma int,
    FOREIGN KEY (PlayerId) REFERENCES Players(Id)
);
