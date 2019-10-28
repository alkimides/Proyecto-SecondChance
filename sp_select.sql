Create Procedure [SecondChance].[sp_select]
	@Username varchar(15),
	@Password varchar(20)
as
begin
	declare @Count int

	select @Count = COUNT(Username)
	from [SecondChance].Users where [Username] = @Username AND [Password] = @Password

	if (@Count = 1)
	begin 
		Select 1 as codereturn
	end
	else
	begin
		select -1 as codereturn
	end
End
























































