USE [AddressBookDB]
GO
--===================================================================
--Created Sp To Get Sorted ER Person By Name(UC6-UC10) 
--===================================================================
CREATE PROCEDURE [dbo].[spErSortedContactByName]
	@City varchar(50)
AS
	SELECT ab.AddressBookId,ab.AddressBookName,pd.PersonId,pd.FirstName,pd.LastName,pd.Address,pd.City,pd.StateName,pd.ZipCode,
	pd.PhoneNum,pd.EmailId,pt.PersonType,pt.PersonTypeId FROM
	Address_Book AS ab 
	INNER JOIN Persons_Details AS pd ON ab.AddressBookId = pd.AddressBookId And City = @City
	INNER JOIN Persons_Details_Type as ptm On ptm.PersonId = pd.PersonId
	INNER JOIN Person_Types AS pt ON pt.PersonTypeId = ptm.PersonTypeId Order By FirstName;