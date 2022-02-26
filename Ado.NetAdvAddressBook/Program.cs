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
                    Console.WriteLine("1: Insert Data Into AddressBook \n2: Update Existing Contact \n3: Delete Contact \n4: Display Addressbook Data \n5: Retrive Record By City Or State"+
                                "\n6: Count By City And State \n7: Retrieve Sorted Person Records \n8: Count Based on Contact Type \n9: Exit");
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
                                Console.Write("Enter Your FirstName To Update Contact : ");
                                string fName = Console.ReadLine();
                                result = AddressBookRepository.UpdateDbTableBasedOnName(fieldName, fieldValue, fName);
                                Console.WriteLine(result);
                                break;
                            case 3:
                                //Calling the delete method to delete contact from db table(UC5)
                                Console.Write("Enter The FirstName To Delete Contact : ");
                                string firstName = Console.ReadLine(); 
                                result = AddressBookRepository.DeleteContactBasedOnName(firstName);
                                Console.WriteLine(result);
                                break;
                            case 4:
                                //Calling getallcontact method to display contact details(UC5)
                                AddressBookRepository.GetAllContact();
                                break;
                            case 5:
                                //Calling the retreive records by city or state method(UC6)
                                Console.Write("Enter The City Name : ");
                                string city = Console.ReadLine();
                                Console.Write("Enter The State Name : ");
                                string state = Console.ReadLine();
                                result = AddressBookRepository.RetreivePersonBasedOnCityOrState(city, state);
                                Console.WriteLine(result);
                                break;
                            case 6:
                                //Calling contactcount method to get size of the addressbook(UC7)
                                result = AddressBookRepository.ContactCountByCityandState();
                                Console.WriteLine(result);
                                break;
                            case 7:
                                //Calling sort contact method to get sorted person name using city(UC8)
                                Console.Write("Enter The City Name : ");
                                string cityName = Console.ReadLine();
                                result = AddressBookRepository.GetSortedCityContactByName(cityName);
                                Console.WriteLine(result);
                                break;
                            case 8:
                                //Calling count by contact type method(UC9)
                                result = AddressBookRepository.GetCountByContactType();
                                Console.WriteLine(result);
                                break;
                            case 9:
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
