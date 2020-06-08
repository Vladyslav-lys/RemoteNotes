create schema if not exists remotenotes;
use remotenotes;

CREATE TABLE `accounts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CreateTime` datetime(6) NOT NULL,
  `ModifyTime` datetime(6) NOT NULL,
  `Photo` longblob DEFAULT NULL,
  `FirstName` longtext,
  `LastName` longtext,
  `Nickname` longtext,
  `Birthday` datetime(6) NOT NULL,
  `Email` longtext,
  PRIMARY KEY (`Id`)
);

CREATE TABLE `notes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AccountId` int DEFAULT NULL,
  `PublishTime` datetime(6) NOT NULL,
  `ModifyTime` datetime(6) NOT NULL,
  `Image` longblob DEFAULT NULL,
  `Text` longtext,
  `Title` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_Notes_AccountId` (`AccountId`),
  CONSTRAINT `FK_Notes_Accounts_AccountId` FOREIGN KEY (`AccountId`) REFERENCES `accounts` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AccountId` int DEFAULT NULL,
  `Login` longtext,
  `Password` longtext,
  `IsActive` bit(1) NOT NULL,
  `AccessLevel` smallint DEFAULT 1,
  PRIMARY KEY (`Id`),
  KEY `IX_Users_AccountId` (`AccountId`),
  CONSTRAINT `FK_Users_Accounts_AccountId` FOREIGN KEY (`AccountId`) REFERENCES `accounts` (`Id`) ON DELETE RESTRICT
);

INSERT INTO remotenotes.accounts (CreateTime, ModifyTime, FirstName, LastName, Nickname, Birthday, Email)
	VALUES ('2019-01-01', '2019-01-30', 'Alexander', 'Bilakovskyi', 'AlexBel', '1998-08-05', 'AlexBel@mail.ru'); 
INSERT INTO remotenotes.accounts (CreateTime, ModifyTime, FirstName, LastName, Nickname, Birthday, Email)
	VALUES ('2019-01-01', '2019-01-30', 'Roman', 'Savchenko', 'RomanSav', '1997-01-01', 'RomanSav@mail.ru'); 
INSERT INTO remotenotes.accounts (CreateTime, ModifyTime, FirstName, LastName, Nickname, Birthday, Email)
	VALUES ('2019-01-01', '2019-01-30', 'Vladislav', 'Lysenko', 'Vlad1998', '1998-03-08', 'LysenkoVlad@mail.ru'); 
    
INSERT INTO remotenotes.users (AccountId, Login, Password, IsActive, AccessLevel)
	VALUES (1, 'login', 'pass', 1, 2);
INSERT INTO remotenotes.users (AccountId, Login, Password, IsActive, AccessLevel)
	VALUES (2, 'root', 'toor', 1, 3);
INSERT INTO remotenotes.users (AccountId, Login, Password, IsActive, AccessLevel)
	VALUES (3, 'admin', 'admin', 1, 4);
    
INSERT INTO remotenotes.notes (AccountId, PublishTime, ModifyTime, Text, Title)
	VALUES (1, '2019-02-02', '2019-02-02', 'Some text for my note just to fill the database1', 'Some title to be here1');
INSERT INTO remotenotes.notes (AccountId, PublishTime, ModifyTime, Text, Title)
	VALUES (1, '2019-03-03', '2019-03-03', 'Some text for my note just to fill the database2', 'Some title to be here2');
INSERT INTO remotenotes.notes (AccountId, PublishTime, ModifyTime, Text, Title)
	VALUES (2, '2019-04-04', '2019-04-04', 'Some text for my note just to fill the database3', 'Some title to be here3');
