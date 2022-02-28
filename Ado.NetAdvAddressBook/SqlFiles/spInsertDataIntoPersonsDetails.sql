USE [AddressBookDB]
GO
ALTER PROCEDURE [dbo].[spInsertDataIntoPersonsDetails] 
	@PersonTypeId Int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@Address varchar(255),
	@City varchar(50),
	@StateName varchar(50),
	@ZipCode int,
	@PhoneNum bigint,
	@EmailId varchar(50),
	@DateAdded date,
	@id INT OUTPUT
AS
	INSERT INTO Persons_Details VALUES(@PersonTypeId,@FirstName,@LastName,@Address,@City,@StateName,@ZipCode,@PhoneNum,@EmailId,@DateAdded);
SET @id= SCOPE_IDENTITY()
	RETURN @id;
