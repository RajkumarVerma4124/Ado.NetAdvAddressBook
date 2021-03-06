USE [AddressBookDB]
GO
/****** Object:  StoredProcedure [dbo].[spGetErRecordByCityOrState]    Script Date: 2/28/2022 3:37:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetErRecordByCityOrState] 
	@City varchar(50),
	@StateName varchar(50)
AS
	SELECT ab.AddressBookId,ab.AddressBookName,pd.PersonId,pd.FirstName,pd.LastName,pd.Address,pd.City,pd.StateName,pd.ZipCode,pd.DateAdded,
	pd.PhoneNum,pd.EmailId,pt.PersonType,pt.PersonTypeId FROM
	Address_Book AS ab 
	INNER JOIN Persons_Details AS pd ON ab.AddressBookId = pd.AddressBookId AND (pd.City=@City Or pd.StateName=@StateName)
	INNER JOIN Persons_Details_Type as ptm On ptm.PersonId = pd.PersonId
	INNER JOIN Person_Types AS pt ON pt.PersonTypeId = ptm.PersonTypeId;