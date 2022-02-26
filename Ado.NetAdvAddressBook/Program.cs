using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NetAdvAddressBook
{
    public class Program
    {
        //Declared a contact object
        public static Contact contact = new Contact();
        //Declaring variables
        public static string result;
        //Entry of the main program
        public static void Main(string[] args)
        {
            //Displaying the welcome message
            Console.WriteLine("Welcome To The Ado.Net Advance AddressBook Program");
            Console.ReadLine();
            try
            {
                while (true)
                {
                    Console.WriteLine("1: Insert Data Into AddressBook \n2: Update Existing Contact \n3: Exit");
                    Console.Write("Enter a choice from above : ");
                    bool flag = int.TryParse(Console.ReadLine(), out int choice);
                    if (flag)
                    {
                        switch (choice)
                        {
                            case 1:
                                //Calling the addressbook repo method to add data into database(UC3)
                                var resContact = AddContact.PersonDetails(contact);
                                result = AddressBookRepository.InsertDataIntoDbTable(resContact);
                                Console.WriteLine(result);
                                break;
                            case 2:
                                //Calling the update contact method to edit contact(UC1&UC2)
                                Console.Write("Which Field You Want To Edit : ");
                                string fieldName = Console.ReadLine();
                                Console.Write("Enter The Field Value To Update : ");
                                string fieldValue = Console.ReadLine();
                                Console.Write("Enter Your FirstName : ");
                                string fName = Console.ReadLine();
                                result = AddressBookRepository.UpdateDbTableBasedOnName(fieldName, fieldValue, fName);
                                Console.WriteLine(result);
                                break;
                            case 3:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Enter right choice");
                                continue;
                        }
                    }
                    else
                        Console.WriteLine("Enter some choice");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
