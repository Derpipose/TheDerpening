CREATE TABLE "Todos" (
    "Id" serial NOT NULL,
    "Title" varchar(90) NOT NULL,
    "IsTaskCompleted" Boolean NOT NULL
);

CREATE TABLE "Players" (
    "Id" serial NOT NULL,
    "Name" varchar(60) NOT NULL,
    "Keyword" varchar(60) NOT NULL,
    PRIMARY KEY ("Id")
);

CREATE TABLE "Characters" (
    "Id" serial NOT NULL,
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
