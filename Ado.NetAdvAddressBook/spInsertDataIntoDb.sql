-- =============================================
--Create SP To Insert Data Into Db(UC3)
-- =============================================
Create PROCEDURE [dbo].[spInsertDataIntoDb] 
	@FirstName varchar(50),
	@LastName varchar(50),
	@Address varchar(255),
	@City varchar(50),
	@StateName varchar(50),
	@ZipCode int,
	@PhoneNum bigint,
	@EmailId varchar(50),
	@AddressBookName varchar(50),
	@AddressBookType varchar(50)
AS
	Insert Into AddressBook Values(@FirstName, @LastName, @Address, @City, @StateName, @ZipCode, @PhoneNum, @EmailId, @AddressBookName, @AddressBookType)
	