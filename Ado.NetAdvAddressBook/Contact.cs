using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NetAdvAddressBook
{
    /// <summary>
    /// Created The Class To Declare Contact Properties(UC2)
    /// </summary>
    public class Contact
    {
        //Declaring contact properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long PhoneNumber { get; set; }
        public long ZipCode { get; set; }
        public string EmailId { get; set; }
        public string AddressBookName { get; set; }
        public int AddressBookId { get; set; }
        public int PersonId { get; set; }
        public int ContactTypeId { get; set; }
        public string ContactType { get; set; }

        //Method to override string method(UC5)
        public override string ToString()
        {
            return $"First Name : {FirstName} || Last Name : {LastName} \nAddress : {Address} || City : {City} || State : {State} || ZipCode = {ZipCode}"+
                $"\nPhone No : {PhoneNumber} \nEmail Id : {EmailId} \nAddressBook Name : {AddressBookName} || AddressBook Type : {ContactType}\n";
        }
    }
}
