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
    }
}
