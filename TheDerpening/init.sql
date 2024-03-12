CREATE TABLE "Todos" (
    "Id" int NOT NULL,
    "Title" varchar(90) NOT NULL,
    "IsTaskCompleted" bit NOT NULL
);

CREATE TABLE "Players" (
    "Id" int NOT NULL,
    "Name" varchar(60) NOT NULL,
    "Keyword" varchar(60) NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE "Characters" (
    "Id" int NOT NULL,
    "PlayerId" int NOT NULL,
    "CharacterName" varchar(90) NOT NULL,
    "Strength" int,
    "Dexterity" int,
    "Constitution" int,
    "Intelligence" int,
    "Wisdom" int, 
    "Charisma" int,
    FOREIGN KEY ("PlayerId") REFERENCES "Players"("Id")
);
