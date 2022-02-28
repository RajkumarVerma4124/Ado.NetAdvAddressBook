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
    /// Created The AddressBook Transaction Class To Add Data Into Mutiple Tables(UC11)
    /// </summary>
    public class AddressBookTransaction
    {
        //Give path for Database Connection(UC11)
        public static string connectionString = @"Data Source=RAJ-VERMA;Initial Catalog=AddressBookDb;Integrated Security=True;";
        //Represents a connection to Sql Server Database(UC11)
        public static SqlConnection sqlConnection = null;

        //Method to add a column in the addressbook table(UC11)
        public static string AlterTableAddDateAddedColumn()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //Begins sql transaction
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;
                try
                {
                    //Add column DateAdded in person details
                    string query = $"Alter Table Persons_Details Add DateAdded Date;";
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Transaction = sqlTransaction;
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        sqlTransaction.Commit();
                        return "Added the coulumn successfully";
                    }
                    else
                    {
                        return "Unsuccessfull";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        //Rollback to the point before exception
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollBack)
                    {
                        return exRollBack.Message;
                    }
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return default;
        }

        //Method to update dateadded column in addressbook table(UC11)
        public static string UpdateDateAddedColumn()
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //Begins sql transaction
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;
                try
                {
                    //set command text to command object
                    sqlCommand.CommandText = @"UPDATE Persons_Details SET DateAdded='2016-05-06' WHERE PersonId=1";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = @"UPDATE Persons_Details SET DateAdded='2019-01-01' WHERE PersonId=2";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = @"UPDATE Persons_Details SET DateAdded='2020-02-21' WHERE PersonId=3";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = @"UPDATE Persons_Details SET DateAdded='2021-05-22' WHERE PersonId=4";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = @"UPDATE Persons_Details SET DateAdded='2019-11-15' WHERE PersonId=5";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = @"UPDATE Persons_Details SET DateAdded='2017-10-16' WHERE PersonId=6";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = @"UPDATE Persons_Details SET DateAdded='2018-04-11' WHERE PersonId=7";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = @"UPDATE Persons_Details SET DateAdded='2019-02-09' WHERE PersonId=8";
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.CommandText = @"UPDATE Persons_Details SET DateAdded='2020-01-13' WHERE PersonId=9";
                    sqlCommand.Transaction = sqlTransaction;
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        sqlTransaction.Commit();
                        return "Updated the coulumn successfully";
                    }
                    else
                    {
                        return "Unsuccessfull";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        //Rollback to the point before exception
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollBack)
                    {
                        return exRollBack.Message;
                    }
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return default;
        }

        //Method to retrive addressbook data based on dateadded column in addressbook table(UC11)
        public static string RetrieveDataBasedOnDateRange(DateTime date)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //Begins sql transaction
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;
                try
                {
                    //set command text to command object
                    sqlCommand = new SqlCommand("dbo.spGetErRecordByDateRange", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@DateAdded", date);
                    sqlCommand.Transaction = sqlTransaction;
                    //Execute command
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    //Check Result set has rows or not
                    if (reader.HasRows)
                    {
                        //Parse untill  rows are null
                        while (reader.Read())
                        {
                            //Print deatials that are retrived
                            AddressBookERRepository.PrintContact(reader);
                        }
                        reader.Close();
                        sqlTransaction.Commit();
                        return "Found the data successfully";
                    }
                    else
                    {
                        return "Unsuccessfull";
                    }                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        //Rollback to the point before exception
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollBack)
                    {
                        return exRollBack.Message;
                    }
                }
            }
            return default;
        }

        //Method to insert data into multiple tables(UC11)
        public static string InsertDataIntoMulTableUsingTransaction(Contact contact)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                //Open the connection
                sqlConnection.Open();
                //Start a local transactions
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                //Enlist a command int the current transaction
                SqlCommand command = sqlConnection.CreateCommand();
                //Setting the command to transaction
                command.Transaction = sqlTransaction;
                try
                {
                    //Executing different commands objects
                    command = new SqlCommand("dbo.spInsertDataIntoPersonsDetails", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonTypeId", contact.ContactTypeId);
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@Address", contact.Address);
                    command.Parameters.AddWithValue("@City", contact.City);
                    command.Parameters.AddWithValue("@StateName", contact.State);
                    command.Parameters.AddWithValue("@ZipCode", contact.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNum", contact.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailId", contact.EmailId);
                    command.Parameters.AddWithValue("@DateAdded", contact.DateAdded);
                    command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.Transaction = sqlTransaction;
                    var result = command.ExecuteNonQuery();
                    int newId = Convert.ToInt32(command.Parameters["@id"].Value.ToString());
                    //Adding the data into person details type table
                    string query = $"INSERT INTO Persons_Details_Type VALUES({newId},{contact.ContactTypeId})";
                    command = new SqlCommand(query, sqlConnection);
                    command.Transaction = sqlTransaction;
                    var newResult = command.ExecuteNonQuery();
                    if (newResult != 0)
                    {
                        //if all executes are success commit the transaction
                        sqlTransaction.Commit();
                        return $"Inserted The Data Successfully";
                    }
                    else
                        return $"Unsuccesfull";
                }
                catch (Exception ex)
                {
                    //Handle the eception if the transaction fails to commit
                    Console.WriteLine(ex.Message);
                    try
                    {
                        //Attempt to rollback the transaction
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollBack)
                    {
                        return exRollBack.Message;
                    }
                    return default;
                }
            }
        }
    }
}
