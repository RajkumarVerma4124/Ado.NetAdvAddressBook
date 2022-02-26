USE [AddressBookDB]
GO
--===================================================================
--Created Sp To Get ER Record By City Or State(UC6-UC10) 
--===================================================================
Alter PROCEDURE [dbo].[spGetErRecordByCityOrState] 
	@City varchar(50),
	@StateName varchar(50)
AS
	SELECT ab.AddressBookId,ab.AddressBookName,pd.PersonId,pd.FirstName,pd.LastName,pd.Address,pd.City,pd.StateName,pd.ZipCode,
	pd.PhoneNum,pd.EmailId,pt.PersonType,pt.PersonTypeId FROM
	Address_Book AS ab 
	INNER JOIN Persons_Details AS pd ON ab.AddressBookId = pd.AddressBookId AND (pd.City=@City Or pd.StateName=@StateName)
	INNER JOIN Persons_Details_Type as ptm On ptm.PersonId = pd.PersonId
	INNER JOIN Person_Types AS pt ON pt.PersonTypeId = ptm.PersonTypeId;
