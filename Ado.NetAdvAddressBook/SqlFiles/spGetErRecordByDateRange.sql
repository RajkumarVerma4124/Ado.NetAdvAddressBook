USE [AddressBookDB]
GO
ALTER PROCEDURE [dbo].[spGetErRecordByDateRange] 
	@DateAdded Date
AS
	SELECT ab.AddressBookId,ab.AddressBookName,pd.PersonId,pd.FirstName,pd.LastName,pd.Address,pd.City,pd.StateName,pd.ZipCode,pd.DateAdded,
	pd.PhoneNum,pd.EmailId,pt.PersonType,pt.PersonTypeId FROM
	Address_Book AS ab 
	INNER JOIN Persons_Details AS pd ON ab.AddressBookId = pd.AddressBookId AND pd.DateAdded BETWEEN @DateAdded AND getdate()
	INNER JOIN Persons_Details_Type as ptm On ptm.PersonId = pd.PersonId
	INNER JOIN Person_Types AS pt ON pt.PersonTypeId = ptm.PersonTypeId;