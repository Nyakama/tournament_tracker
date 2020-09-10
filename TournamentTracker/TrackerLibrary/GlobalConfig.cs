using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{   /// <summary>
    /// Static class to hold the connection interface
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// A method that identifies which classes to put in that list
        /// </summary>
        public static IDataConnection Connection { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <param name="textFiles"></param>
        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                // TODO - Set up the SQL Connector properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                // TODO - Create the Text Connection
                TextConnector text = new TextConnector();
                Connection = text; 
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
