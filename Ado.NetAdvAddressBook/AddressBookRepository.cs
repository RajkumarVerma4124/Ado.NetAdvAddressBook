using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NetAdvAddressBook
{
    /// <summary>
    /// Created The AdressBookRepository Class To Insert,Update Retrieve The Data From DB(UC1)
    /// </summary>
    public class AddressBookRepository
    {
        //Give path for Database Connection(UC1)
        public static string connectionString = @"Data Source=RAJ-VERMA;Initial Catalog=AddressBookDb;Integrated Security=True;";
        //Represents a connection to Sql Server Database(UC1)
        public static SqlConnection sqlConnection = null;
        //Creating the object of contact class
        public static Contact contact = new Contact();
        //Method to insert data from user to db table(UC3)
        public static string InsertDataIntoDbTable(Contact contact)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.spInsertDataIntoDb", sqlConnection);
                    //Setting command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", contact.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", contact.Address);
                    sqlCommand.Parameters.AddWithValue("@City", contact.City);
                    sqlCommand.Parameters.AddWithValue("@StateName", contact.State);
                    sqlCommand.Parameters.AddWithValue("@ZipCode", contact.ZipCode);
                    sqlCommand.Parameters.AddWithValue("@PhoneNum", contact.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@EmailId", contact.EmailId);
                    sqlCommand.Parameters.AddWithValue("@AddressBookName", contact.AddressBookName);
                    sqlCommand.Parameters.AddWithValue("@AddressBookType", contact.ContactType);
                    sqlConnection.Open();
                    //Return the number of rows updated
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                        return "Inserted Data Succesfully";
                    else
                        return "Unsucessfull";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Method to modify existing contact from db table using their name(UC4)
        public static string UpdateDbTableBasedOnName(string fieldName, string fieldValue, string fName)
        {
            try
            {
                //Open Connection
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string query = $"Update AddressBook Set {fieldName} = '{fieldValue}' where FirstName = '{fName}'";
                    //Pass query to TSql
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                        return "Updated Data Succesfully";
                    else
                        return "Unsuccesfull";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally 
            {
                sqlConnection.Close();
            }
        }

        //Method to delete existing contact from db table using their name(UC5)
        public static string DeleteContactBasedOnName(string fName)
        {
            try
            {
                //Open Connection
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string query = $"Delete From AddressBook Where FirstName = '{fName}'";
                    //Pass query to TSql
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                        return "Deleted Data Succesfully";
                    else
                        return "Unsuccesfull";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Method to retreive person by city or state from db(UC6)
        public static string RetreivePersonBasedOnCityOrState(string city, string state)
        {
            try
            {
                //Open Connection
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string query = $"Select * From AddressBook Where City = '{city}' Or StateName = '{state}'";
                    //Passing query to sqlcommand
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            PrintContact(sqlDataReader);
                        }
                        return "Found The Record SuccessFully";
                    }
                    else
                        return "No Record Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Method to retreive person by city or state from db(UC7)
        public static string ContactCountByCityandState()
        {
            try
            {
                //Open Connection
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string query = $"Select Count(*),StateName,City From AddressBook Group By StateName,City";
                    //Passing query to sqlcommand
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("Count : {0} \tState : {1} \tCity : {2}", sqlDataReader[0], sqlDataReader[1], sqlDataReader[2]);
                        }
                        return "Found The Record SuccessFully";
                    }
                    else
                        return "No Record Found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Method to fetch all contact records(UC5)
        public static void GetAllContact()
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string query = "Select * from AddressBook";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            PrintContact(reader);
                    }
                    else
                        Console.WriteLine("There is no records in the db table");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Method to print contact details(UC5)
        public static void PrintContact(SqlDataReader sqlDataReader)
        {
            contact.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
            contact.LastName = Convert.ToString(sqlDataReader["LastName"]);
            contact.Address = Convert.ToString(sqlDataReader["Address"]);
            contact.City = Convert.ToString(sqlDataReader["City"]);
            contact.State = Convert.ToString(sqlDataReader["StateName"]);
            contact.ZipCode = Convert.ToInt64(sqlDataReader["ZipCode"]);
            contact.PhoneNumber = Convert.ToInt64(sqlDataReader["PhoneNum"]);
            contact.EmailId = Convert.ToString(sqlDataReader["EmailId"]);
            contact.AddressBookName = Convert.ToString(sqlDataReader["AddressBookName"]);
            contact.ContactType = Convert.ToString(sqlDataReader["AddressBookType"]);
            Console.WriteLine(contact);
        }
    }
}
