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
        public string ContactType { get; set; }
    }
}
