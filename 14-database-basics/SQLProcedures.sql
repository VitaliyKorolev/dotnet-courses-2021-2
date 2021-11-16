

CREATE PROCEDURE DeleteUser(@userId int)
As
    DELETE FROM UsersRewards WHERE UserID = @userId;
	DELETE FROM Users WHERE Id = @userId
go

CREATE PROCEDURE DeleteReward(@rewardId int)
As
    DELETE FROM UsersRewards WHERE RewardID = @rewardId;
	DELETE FROM Rewards WHERE Id = @rewardId
go

INSERT Users(Id, Name, LastName, Birthdate, Age) VALUES(2,'valera', 'Andreev', '20000101', 21)

INSERT UsersRewards(UserId, RewardId) VALUES(1,2)
INSERT UsersRewards(UserId, RewardId) VALUES(1,1)
INSERT UsersRewards(UserId, RewardId) VALUES(2,1)
INSERT UsersRewards(UserId, RewardId) VALUES(2,2)

EXEC DeleteReward @rewardId=2

CREATE PROCEDURE AddReward(@id int, @title nvarchar(50), @description nvarchar(250))
As
    INSERT Rewards(Id, Title, Description) VALUES(@id, @title, @description)
go

EXEC AddReward @id=2, @title = 'Darvin', @description = ''

CREATE PROCEDURE AddUser(@id int, @name nvarchar(50), @lastName nvarchar(50), @birthday date, @age int)
As
    INSERT Users(Id, Name, LastName, Birthdate, Age) VALUES(@id, @name, @lastName, @birthday, @age)
go


CREATE PROCEDURE GetRewardsOfUser(@userId int)
As
    SELECT RewardId FROM UsersRewards WHERE UserId = @userId;
go

CREATE PROCEDURE EditReward(@id int, @title nvarchar(50), @description nvarchar(250))
As
    UPDATE Rewards 
	SET Title=@title, Description = @description
	WHERE Id = @id
go

EXEC EditReward @id = 2, @title = 'AVCHG', @description = 'dfhfdh'

CREATE PROCEDURE EditUser(@id int, @name nvarchar(50), @lastName nvarchar(50), @birthday date, @age int)
As
    UPDATE Users 
	SET Name=@name, LastName = @lastName, Birthdate =@birthday, Age = @age
	WHERE Id = @id
go

EXEC EditUser @id=3, @name='fdhdfh', @lastName ='fdhdhf', @birthday ='18000101', @age=200