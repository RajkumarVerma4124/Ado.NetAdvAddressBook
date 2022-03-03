using Ado.NetAdvAddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Ado.NetAdvAddressBookTesting
{
    [TestClass]
    public class AddressBookTesting
    {
        //Testing to check the data is inserted to db table or not(UC3)
        [TestMethod]
        [DataRow("Ankit", "Varma", "Nerul", "NaviMumbai", "Maharashtra", 854697, 9658742130, "abc112@gmail.com", "ProfessionAddressBook", "Profession", "Inserted Data Succesfully")]
        [DataRow("Yash", "Sarjekar", "Nanded", "Pune", "Maharashtra", 741258, 9547861320, "abc705@gmail.com", "FreindsAddressBook", "Freinds", "Inserted Data Succesfully")]
        public void InsertIntoDBTable(string fname, string lname, string address, string city, string state, long zipcode, long phoneNum, string emailId, string addrBookName, string AddrBookType, string expected)
        {
            Contact addressBook = new Contact();
            addressBook.FirstName = fname;
            addressBook.LastName = lname;
            addressBook.Address = address;
            addressBook.City = city;
            addressBook.State = state;
            addressBook.ZipCode = zipcode;
            addressBook.PhoneNumber = phoneNum;
            addressBook.EmailId = emailId;
            addressBook.AddressBookName = addrBookName;
            addressBook.ContactType = AddrBookType;
            var actual = AddressBookRepository.InsertDataIntoDbTable(addressBook);
            Assert.AreEqual(expected, actual);
        }

        //Testing to check the update method is upating the value in db or not using name(UC4)
        [TestMethod]
        [DataRow("EmailId", "abc786@gmail.com", "Raj", "Updated Data Succesfully")]
        [DataRow("EmailId", "abc786", "konkan", "Unsuccesfull")]
        public void GivenUpdateQueryReturnResult(string fieldName, string fieldValue, string fName, string expected)
        {
            var actual = AddressBookRepository.UpdateDbTableBasedOnName(fieldName, fieldValue, fName);
            Assert.AreEqual(expected, actual);
        }

        //Testing to check the delete method is deleting the value in db or not using name(UC5)
        [TestMethod]
        [DataRow("Yash", "Deleted Data Succesfully")]
        [DataRow("Ankit", "Deleted Data Succesfully")]
        [DataRow("konkan", "Unsuccesfull")]
        public void GivenDeleteQueryReturnResult(string fName, string expected)
        {
            var actual = AddressBookRepository.DeleteContactBasedOnName(fName);
            Assert.AreEqual(expected, actual);
        }

        //Testing the retreive records and er records by city or state method to check if data is found or not(UC6-UC12)
        [TestMethod]
        [DataRow("Mumbai", "Maharashtra", "Found The Record SuccessFully")]
        [DataRow("konkan", "kolaba", "No Record Found")]
        public void GivenRetriveQueryReturnResult(string city, string state, string expected)
        {
            var actualEmployee = AddressBookRepository.RetreivePersonBasedOnCityOrState(city, state);
            var actualErEmployee = AddressBookERRepository.RetreiveErContactByCityOrState(city, state);
            Assert.AreEqual(actualEmployee, expected);
            Assert.AreEqual(actualErEmployee, expected);
        }

        //Testing the count contact and er contact by city and state method to check if data is found or not(UC7-12)
        [TestMethod]
        [DataRow("Found The Record SuccessFully")]
        public void GivenCountQueryReturnResult(string expected)
        {
            var actualEmployee = AddressBookRepository.ContactCountByCityandState();
            var actualErEmployee = AddressBookERRepository.GetErContactCountByCityandState();
            Assert.AreEqual(actualEmployee, expected);
            Assert.AreEqual(actualErEmployee, expected);
        }

        //Testing the sort contact by persons name and er person to check if data is found or not(UC8-12)
        [TestMethod]
        [DataRow("Mumbai","Found The Record SuccessFully")]
        [DataRow("NaviMumbai","Found The Record SuccessFully")]
        [DataRow("kalamboli", "No Record Found")]
        public void GivenOrderByQueryReturnResult(string city, string expected)
        {
            var actualEmployee = AddressBookRepository.GetSortedCityContactByName(city);
            var actualErEmployee = AddressBookERRepository.GetSortedERContactByNameGivenCity(city);
            Assert.AreEqual(actualEmployee, expected);
            Assert.AreEqual(actualErEmployee, expected);
        }

        //Testing the count contact by contact and er contact type to check if data is found or not(UC9-UC12)
        [TestMethod]
        [DataRow("Found The Record SuccessFully")]
        public void GivenCountByTypeQueryReturnResult(string expected)
        {
            var actualEmployee = AddressBookRepository.GetCountByContactType();
            var actualErEmployee = AddressBookERRepository.GetCountByERContactType();
            Assert.AreEqual(actualEmployee, expected);
            Assert.AreEqual(actualErEmployee, expected);
        }

        //Testing the count contact by er contact type to check if data is found or not(UC10)
        [TestMethod]
        [DataRow("Found The Record SuccessFully")]
        public void GivenCountByABNameQueryReturnResult(string expected)
        {
            var actual = AddressBookERRepository.GetCountByERAddrBookName();
            Assert.AreEqual(expected, actual);
        }

        //Testing to check the data is inserted to multiple table or not(UC11)
        [TestMethod]
        [DataRow(1,"Yash", "Sarjekar", "Nanded", "Pune", "Maharashtra", 854697, 9658742130, "yashs@gmail.com", "2019-02-02", "Inserted The Data Successfully")]
        public void InsertIntoMulTableDB(int personTypeId, string fname, string lname, string address, string city, string state, long zipcode, long phoneNum, string emailId, string date, string expected)
        {
            Contact contact = new Contact();
            contact.ContactTypeId = personTypeId;
            contact.FirstName = fname;
            contact.LastName = lname;
            contact.Address = address;
            contact.City = city;
            contact.State = state;
            contact.ZipCode = zipcode;
            contact.PhoneNumber = phoneNum;
            contact.EmailId = emailId;
            contact.DateAdded = Convert.ToDateTime(date);
            var actual =AddressBookTransaction.InsertDataIntoMulTableUsingTransaction(contact);
            Assert.AreEqual(expected, actual);
        }

        //Testing to check the mul person data is inserted to multiple table or not using (UC12)
        [TestMethod]
        [DataRow("Successfull")]
        public void TestInsertMulPersonIntoMulTableUsingThread(string expected)
        {
            List<Contact> contacts = new List<Contact>()
             {
                 new Contact { ContactTypeId = 3, FirstName = "Jerin", LastName = "Raju", Address = "Airoli", City = "NaviMumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9678540123, EmailId = "yashs@gmail.com", DateAdded = Convert.ToDateTime("2022-02-02")},
                 new Contact { ContactTypeId = 3, FirstName = "Abhishek", LastName = "Bhoir", Address = "Nerul", City = "NaviMumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9658740123, EmailId = "abhi@gmail.com", DateAdded = Convert.ToDateTime("2019-03-02")},
                 new Contact { ContactTypeId = 3, FirstName = "Mahipal", LastName = "Purohit", Address = "Powai", City = "Mumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9654780123, EmailId = "mahi@gmail.com", DateAdded = Convert.ToDateTime("2020-04-02")},
                 new Contact { ContactTypeId = 2, FirstName = "Dibin", LastName = "Dasan", Address = "Powai", City = "Mumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9658741233, EmailId = "dibin@gmail.com", DateAdded = Convert.ToDateTime("2019-05-02")},
                 new Contact { ContactTypeId = 2, FirstName = "Rahul", LastName = "Krishna", Address = "Powai", City = "Mumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9658470123, EmailId = "rahul@gmail.com", DateAdded = Convert.ToDateTime("2021-06-02")},
                 new Contact { ContactTypeId = 1, FirstName = "Shubham", LastName = "Verma", Address = "Sultanpur", City = "Noida", State = "Delhi", ZipCode = 854697, PhoneNumber = 9658742130, EmailId = "shubham@gmail.com", DateAdded = Convert.ToDateTime("2018-07-02")},
             };
            var actual = AddressBookTransaction.AddMulPersonsToABUsingThread(contacts);
            Assert.AreEqual(expected, actual);
        }

        //Testing to retrive mul records using thread(UC14)
        [TestMethod]
        [DataRow("EmailId", "abc786@gmail.com", "Raj", "Updated Data Succesfully")]
        [DataRow("EmailId", "abc786", "konkan", "Unsuccesfull")]
        public void TestMulUpdateFields(string fieldName, string fieldValue, string fName, string expected)
        {
            List<Contact> contacts = new List<Contact>()
             {
                 new Contact { ContactTypeId = 3, FirstName = "Jerin", LastName = "Raju", Address = "Airoli", City = "NaviMumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9678540123, EmailId = "yashs@gmail.com", DateAdded = Convert.ToDateTime("2022-02-02")},
                 new Contact { ContactTypeId = 3, FirstName = "Abhishek", LastName = "Bhoir", Address = "Nerul", City = "NaviMumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9658740123, EmailId = "abhi@gmail.com", DateAdded = Convert.ToDateTime("2019-03-02")},
                 new Contact { ContactTypeId = 3, FirstName = "Mahipal", LastName = "Purohit", Address = "Powai", City = "Mumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9654780123, EmailId = "mahi@gmail.com", DateAdded = Convert.ToDateTime("2020-04-02")},
                 new Contact { ContactTypeId = 2, FirstName = "Dibin", LastName = "Dasan", Address = "Powai", City = "Mumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9658741233, EmailId = "dibin@gmail.com", DateAdded = Convert.ToDateTime("2019-05-02")},
                 new Contact { ContactTypeId = 2, FirstName = "Rahul", LastName = "Krishna", Address = "Powai", City = "Mumbai", State = "Maharashtra", ZipCode = 854697, PhoneNumber = 9658470123, EmailId = "rahul@gmail.com", DateAdded = Convert.ToDateTime("2021-06-02")},
                 new Contact { ContactTypeId = 1, FirstName = "Shubham", LastName = "Verma", Address = "Sultanpur", City = "Noida", State = "Delhi", ZipCode = 854697, PhoneNumber = 9658742130, EmailId = "shubham@gmail.com", DateAdded = Convert.ToDateTime("2018-07-02")},
             };
            var actual = AddressBookTransaction.AddMulPersonsToABUsingThread(contacts);
            Assert.AreEqual(expected, actual);
        }
    }
}
