using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.NetAdvAddressBook
{
    public class AdressBookRepository
    {
        //Give path for Database Connection
        public static string connectionString = @"Data Source=RAJ-VERMA;Initial Catalog=PayRoll_Service;Integrated Security=True;";
        //Represents a connection to Sql Server Database
        SqlConnection sqlConnection = new SqlConnection(connectionString);
    }
}
