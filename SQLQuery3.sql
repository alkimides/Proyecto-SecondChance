USE [DAM_Compartido_DEV]
GO
/****** Object:  StoredProcedure [SecondChance].[sp_Insert]    Script Date: 24/10/2019 10:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [SecondChance].[sp_Insert]
(
	@UserID int output,
	@First_Name varchar(20),
	@Last_Name varchar(20),
	@Birth_Date date,
	@Phone_Number varchar(10),
	@Email varchar(40),
	@Country varchar(50),
	@Adress varchar(50),
	@Password varchar(20),
	@Username varchar (15)
)
as
begin


	

	Declare @Count int
	Declare @codereturn int 

	Select @Count = COUNT(Username)
	from Users where @Username = Username
	if @Count > 0
	Begin

		Set @codereturn = -1
	end
	else
	begin
		set @codereturn = 1
		set nocount on 
		select @UserID = ISNULL(max(UserID), 0) + 1
		from Users
		Insert into Users values(@First_Name,@Last_Name,@Birth_Date,@Phone_Number,@Email,@Country,@Adress,@Password,@Username)
		set nocount off
	end
	select @codereturn as ReturnValue


end




