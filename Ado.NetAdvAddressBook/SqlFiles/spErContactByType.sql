USE [AddressBookDB]
GO
--===================================================================
--Created Sp To Get ER Person By There Type(UC6-UC10) 
--===================================================================
CREATE PROCEDURE [dbo].[spErContactByType]
AS
	Select Count(pdt.PersonTypeId) As RelationType,Pt.PersonType From 
	Persons_Details_Type As pdt 
	INNER JOIN Person_Types AS pt ON pt.PersonTypeId = pdt.PersonTypeId
	INNER JOIN Persons_Details AS pd ON pd.PersonId = pdt.PersonId Group By pdt.PersonTypeId,pt.PersonType;