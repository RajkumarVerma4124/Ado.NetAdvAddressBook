using Ado.NetAdvAddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}
