using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NetAdvAddressBook
{
    /// <summary>
    /// Created AddressBook ER Class To Call AddressBookERRepository methods(UC10-12)
    /// </summary>
    public class AddressBookER
    {
        //Declared a contact object
        public static Contact contact = new Contact();
        //Declaring variables
        public static string result;
        //Entry of the main program
        public static void ERAddressBook()
        {
            //Displaying the welcome message
            Console.WriteLine("\nWelcome To The Ado.Net Advance ER AddressBook Program");
            Console.ReadLine();
            try
            {
                while (true)
                {
                    Console.WriteLine("1: Retrive Record By City Or State \n2: Count By City And State \n3: Retrieve Sorted Person Records \n4: Retreive Count of Contact Based On Contact Type" +
                        "\n5: Retreive Count of AddressBook Based On AddressBook Name \n6: Go Back");
                    Console.Write("Enter a choice from above : ");
                    bool flag = int.TryParse(Console.ReadLine(), out int choice);
                    if (flag)
                    {
                        switch (choice)
                        {
                            case 1:
                                //Calling the retreive er records by city or state method(UC6-UC12)
                                Console.Write("Enter The City Name : ");
                                string city = Console.ReadLine();
                                Console.Write("Enter The State Name : ");
                                string state = Console.ReadLine();
                                result = AddressBookERRepository.RetreiveErContactByCityOrState(city, state);
                                Console.WriteLine(result);
                                break;
                            case 2:
                                //Calling er contactcount method to get size of the addressbook(UC7-UC12)
                                result = AddressBookERRepository.GetErContactCountByCityandState();
                                Console.WriteLine(result);
                                break;
                            case 3:
                                //Calling sort er contact method to get sorted person name using city(UC8-12)
                                Console.Write("Enter The City Name : ");
                                string cityName = Console.ReadLine();
                                result = AddressBookERRepository.GetSortedERContactByNameGivenCity(cityName);
                                Console.WriteLine(result);
                                break;
                            case 4:
                                //Calling count by er contact type method(UC9-12)
                                result = AddressBookERRepository.GetCountByERContactType();
                                Console.WriteLine(result);
                                break;
                            case 5:
                                //Calling count by er contact name method(UC9-12)
                                result = AddressBookERRepository.GetCountByERAddrBookName();
                                Console.WriteLine(result);
                                break;
                            case 6:
                                Program.Main(null);
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
