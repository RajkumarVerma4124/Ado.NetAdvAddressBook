USE [AddressBookDB]
GO
--===================================================================
--Created Sp To Get ER Person Count By City And State(UC6-UC10) 
--===================================================================
Alter PROCEDURE [dbo].[spErContactCountByCityAndState] 
AS
	Select Count(*) As Count,StateName,City from Persons_Details Group By StateName,City;

