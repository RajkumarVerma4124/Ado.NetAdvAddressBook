using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NetAdvAddressBook
{
    public class AddContact
    {
        public static Contact PersonDetails(Contact contact)
        {
            //Creating a contact with person details(UC1)
            Console.Write("Enter Your First Name : ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Enter Your Last Name : ");
            contact.LastName = Console.ReadLine();
            Console.Write("Enter Your Home Address : ");
            contact.Address = Console.ReadLine();
            Console.Write("Enter Your City Name : ");
            contact.City = Console.ReadLine();
            Console.Write("Enter Your State Name : ");
            contact.State = Console.ReadLine();
            Console.Write("Enter Your Area Zip Code : ");
            contact.ZipCode = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Your Phone Number : ");
            contact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Your EmailId : ");
            contact.EmailId = Console.ReadLine();
            Console.Write("Enter The AddressBook Name : ");
            contact.AddressBookName = Console.ReadLine();
            Console.Write("Enter The AddressBook Type : ");
            contact.ContactType = Console.ReadLine();
            return contact;
        }
    }
}
