
DROP TABLE Rewards

CREATE TABLE Rewards (
 Id INT PRIMARY KEY,
 Title NVARCHAR(50),
 Description NVARCHAR(250) NULL,
)

DROP TABLE Users

CREATE TABLE Users (
 Id INT PRIMARY KEY,
 Name NVARCHAR(50),
 LastName NVARCHAR(50),
 Birthday DATE,
 Age INT NULL,
)

CREATE TABLE UsersRewards(
 UserId INT,
 RewardId INT,
 PRIMARY KEY(UserId, RewardId),
 FOREIGN KEY(UserId) REFERENCES Users(Id),
 FOREIGN KEY(RewardId) REFERENCES Rewards(Id),
)

INSERT UsersRewards(UserId, RewardId) VALUES(2,2)
INSERT UsersRewards(UserId, RewardId) VALUES(2,1)