USE [AddressBookDB]
GO
--===================================================================
--Created Sp To Get ER Person By There AddressBook Name(UC6-UC10) 
--===================================================================
CREATE PROCEDURE [dbo].[spErRetrieveContactByABName]
AS
	Select Count(ab.AddressBookId) As AddressBookName,ab.AddressBookName From 
	Address_Book As ab 
	INNER JOIN Persons_Details AS pd ON pd.AddressBookId = ab.AddressBookId Group By ab.AddressBookName,pd.AddressBookId;