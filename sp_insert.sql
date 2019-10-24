Create Procedure [SecondChance].[sp_Insert]
(
	@UserID int,
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
		Insert into Users values(@First_Name,@Last_Name,@Birth_Date,@Phone_Number,@Email,@Country,@Adress,@Password,@Username)
	end
	select @codereturn as ReturnValue
end
