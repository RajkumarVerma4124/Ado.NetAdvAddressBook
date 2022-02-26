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
    public class AdressBookRepository
    {
        //Give path for Database Connection(UC1)
        public static string connectionString = @"Data Source=RAJ-VERMA;Initial Catalog=AddressBookDb;Integrated Security=True;";
        //Represents a connection to Sql Server Database(UC1)
        public static SqlConnection sqlConnection = null;

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
    }
}
