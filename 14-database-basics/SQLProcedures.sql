

CREATE PROCEDURE DeleteUser(@userId int)
As
    DELETE FROM UsersRewards WHERE UserID = @userId;
	DELETE FROM Users WHERE Id = @userId
go

CREATE PROCEDURE DeleteRewardsOfUser(@userId int)
As
    DELETE FROM UsersRewards WHERE UserID = @userId;
go

CREATE PROCEDURE DeleteReward(@rewardId int)
As
    DELETE FROM UsersRewards WHERE RewardID = @rewardId;
	DELETE FROM Rewards WHERE Id = @rewardId
go

INSERT Users(Id, Name, LastName, Birthdate) VALUES(2,'valera', 'Andreev', '20000101')

INSERT UsersRewards(UserId, RewardId) VALUES(1,2)
INSERT UsersRewards(UserId, RewardId) VALUES(1,1)
INSERT UsersRewards(UserId, RewardId) VALUES(2,1)
INSERT UsersRewards(UserId, RewardId) VALUES(2,2)

EXEC DeleteReward @rewardId=2

CREATE PROCEDURE AddReward( @title nvarchar(50), @description nvarchar(250))
As
    INSERT Rewards(Title, Description) VALUES( @title, @description)
go

EXEC AddReward  @title = 'Darvin', @description = ''

CREATE PROCEDURE AddUser( @name nvarchar(50), @lastName nvarchar(50), @birthday date )
As
    INSERT Users(Name, LastName, Birthday) VALUES( @name, @lastName, @birthday );
	SELECT MAX(Id) FROM Users;
go


CREATE PROCEDURE GetRewardsOfUser(@userId int)
As
    SELECT RewardId FROM UsersRewards WHERE UserId = @userId;
go

CREATE PROCEDURE AddRewardToUser(@userId int, @rewardId int )
As
    INSERT UsersRewards(UserId, RewardId) VALUES(@userId,@rewardId)
go

EXEC AddRewardToUser @userId = 2, @rewardId = 1

EXEC EditReward @id = 2, @title = 'AVCHG', @description = 'dfhfdh'


CREATE PROCEDURE EditUser(@id int, @name nvarchar(50), @lastName nvarchar(50), @birthday date)
As
    UPDATE Users 
	SET Name=@name, LastName = @lastName, Birthday =@birthday
	WHERE Id = @id
go
EXEC EditUser @id=2, @name='fdhdfh', @lastName ='fdhdhf', @birthday ='18000101'

USE MyDatabase

INSERT Users(Name, LastName, Birthday) VALUES( 'Tom', 'Hawk', '20000101' );
	SELECT MAX(Id) FROM Users;