using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NetAdvAddressBook
{
    /// <summary>
    /// Created The AdressBookERRepository Class To Insert,Update Retrieve The Data From DB(UC10ToUC12)
    /// </summary>
    public class AddressBookERRepository
    {
        //Give path for Database Connection(UC1)
        public static string connectionString = @"Data Source=RAJ-VERMA;Initial Catalog=AddressBookDb;Integrated Security=True;";
        //Represents a connection to Sql Server Database(UC1)
        public static SqlConnection sqlConnection = null;
        //Creating the object of contact class
        public static Contact contact = new Contact();

        //Method to retreive er person by city or state from db(UC6-UC10)
        public static string RetreiveErContactByCityOrState(string city, string state)
        {
            try
            {
                //Open Connection
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    //Passing stored procedure to sqlcommand
                    SqlCommand sqlCommand = new SqlCommand("dbo.spGetErRecordByCityOrState", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@City", city);
                    sqlCommand.Parameters.AddWithValue("@StateName", state);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            PrintContact(sqlDataReader);
                        }
                        sqlDataReader.Close();
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

        //Method to retreive er person by city or state from db(UC7-UC10)
        public static string GetErContactCountByCityandState()
        {
            try
            {
                //Open Connection
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.spErContactCountByCityAndState", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("Count : {0} \tState : {1} \tCity : {2}", sqlDataReader[0], sqlDataReader[1], sqlDataReader[2]);
                        }
                        sqlDataReader.Close();
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

        //Method to retreive sorted er person city records from db using name(UC8)
        public static string GetSortedERContactByNameGivenCity(string city)
        {
            try
            {
                //Open Connection
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.spErSortedContactByName", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@City", city);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            PrintContact(sqlDataReader);
                        }
                        sqlDataReader.Close();
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

        //Method to retreive count by er contact type from db(UC9)
        public static string GetCountByERContactType()
        {
            try
            {
                //Open Connection
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.spErContactByType", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("ContactCount : {0} \tContactType : {1}", sqlDataReader[0], sqlDataReader[1]);
                        }
                        sqlDataReader.Close();
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

        //Method to retreive count by er addressbook name from db(UC9)
        public static string GetCountByERAddrBookName()
        {
            try
            {
                //Open Connection
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("dbo.spErRetrieveContactByABName", sqlConnection);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("AddressBookCount : {0} \tAddressBookName : {1}", sqlDataReader[0], sqlDataReader[1]);
                        }
                        sqlDataReader.Close();
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

        //Method to print er contact details(UC5-UC10)
        public static void PrintContact(SqlDataReader sqlDataReader)
        {
            contact.AddressBookId = Convert.ToInt32(sqlDataReader["AddressBookId"]);
            contact.ContactTypeId = Convert.ToInt32(sqlDataReader["PersonTypeId"]);
            contact.PersonId = Convert.ToInt32(sqlDataReader["PersonId"]);
            contact.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
            contact.LastName = Convert.ToString(sqlDataReader["LastName"]);
            contact.Address = Convert.ToString(sqlDataReader["Address"]);
            contact.City = Convert.ToString(sqlDataReader["City"]);
            contact.State = Convert.ToString(sqlDataReader["StateName"]);
            contact.ZipCode = Convert.ToInt64(sqlDataReader["ZipCode"]);
            contact.PhoneNumber = Convert.ToInt64(sqlDataReader["PhoneNum"]);
            contact.EmailId = Convert.ToString(sqlDataReader["EmailId"]);
            contact.AddressBookName = Convert.ToString(sqlDataReader["AddressBookName"]);
            contact.ContactType = Convert.ToString(sqlDataReader["PersonType"]);
            contact.DateAdded = (DateTime)sqlDataReader["DateAdded"];
            Console.WriteLine($"AddressBook Id : {contact.AddressBookId} || Contact Type Id : {contact.ContactTypeId} || Person Id : {contact.PersonId} || \nFirst Name : {contact.FirstName} || Last Name : {contact.LastName}"+
                $"\nAddress : {contact.Address} || City : {contact.City} || State : {contact.State} || ZipCode = {contact.ZipCode}"+
                $"\nPhone No : {contact.PhoneNumber} \nEmail Id : {contact.EmailId} \nAddressBook Name : {contact.AddressBookName} || AddressBook Type : {contact.ContactType} \nDate Added : {contact.DateAdded}\n");
        }
    }
}
