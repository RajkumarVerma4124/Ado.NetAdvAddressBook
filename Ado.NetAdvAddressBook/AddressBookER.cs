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
        //Create an object of date time
        public static DateTime date = new DateTime();
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
                        "\n5: Retreive Count of AddressBook Based On AddressBook Name \n6: Add Date Added Table \n7: Update The DateAdded Column \n8: Retreive Data Based On Date Range \n9: Insert Data Into Muliple Table Using Transaction\n10: Go Back");
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
                                //Calling the date added method add new column in db table(UC11)
                                result = AddressBookTransaction.AlterTableAddDateAddedColumn();
                                Console.WriteLine(result);
                                break;
                            case 7:
                                //Calling the date update method to update columns in db table(UC11)
                                result = AddressBookTransaction.UpdateDateAddedColumn();
                                Console.WriteLine(result);
                                break;
                            case 8:
                                //Calling the method to retreive data based on date range from db table(UC11)
                                Console.Write("Enter The Starting Date Of Joining For Employee In yyyy-mm-dd Format: ");
                                date = Convert.ToDateTime(Console.ReadLine());
                                result = AddressBookTransaction.RetrieveDataBasedOnDateRange(date);
                                Console.WriteLine(result);
                                break;
                            case 9:
                                //Adding the new data into multiple table using transactions(UC11)
                                Console.Write("Enter Your Person Type Id i.e 1:Freinds, 2:Profession 3:Family : ");
                                contact.ContactTypeId = Convert.ToInt32(Console.ReadLine());
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
                                Console.Write("Enter The Starting Date Of Joining For Employee In yyyy-mm-dd Format: ");
                                contact.DateAdded = Convert.ToDateTime(Console.ReadLine());
                                result = AddressBookTransaction.InsertDataIntoMulTableUsingTransaction(contact);
                                Console.WriteLine(result);
                                break;
                            case 10:
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
