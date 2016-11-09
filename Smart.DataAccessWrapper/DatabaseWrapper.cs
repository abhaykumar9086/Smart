using Smart.Constants;
using System;
using System.Configuration;
using System.Data;

namespace Smart.DataAccessWrapper
{
    /// <summary>
    /// Master class to handle all SQL Server Database interactions.
    /// </summary>
    public class DatabaseWrapper
    {
        #region Public Properties

        /// <summary>
        /// Gets the default singleton instance.
        /// </summary>
        /// <value>
        /// The default wrapper for SQL Server interactions.
        /// </value>
        public static DatabaseWrapper Default { get { return Singleton<DatabaseWrapper>.Instance; } }

        /// <summary>
        /// Gets the reference for Database Connection Wrapper instance.
        /// </summary>
        /// <value>
        /// Instance for Database Connection Wrapper.
        /// </value>
        public DatabaseConnection Connection { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the instance with ConnectionString name as specified in configuration file.
        /// </summary>
        /// <param name="connectionStringName">Name of the ConnectionString as specified in 
        /// connectionStrings tag in configuration file.</param>
        /// <exception cref="System.ArgumentNullException">No connection string with given name found 
        /// in configuration file.</exception>
        public void InitializeWithConfigurationFile(string connectionStringName = ApplicationConstants.DEFAULT_CONNECTION_STRING_NAME)
        {
            var section = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (section != null)
            {
                Connection = new DatabaseConnection();
                Connection.Initialize(section.ConnectionString);
            }
            else
            {
                throw new ArgumentNullException(string.Format(DataAccessWrapperConstants.EXCEPTION_MESSAGE_CONNECTION_STRING_MISSING, connectionStringName));
            }
        }

        /// <summary>
        /// Creates new wrapper instance for SQL Server command using given Query Text.
        /// </summary>
        /// <param name="sql">SQL Query Statement.</param>
        /// <returns>Wrapper instance for SqlCommand</returns>
        public DatabaseCommand CreateCommand(string sql)
        {
            var command = new DatabaseCommand();

            command.Initialize(Connection, CommandType.Text, sql);

            return command;
        }

        /// <summary>
        /// Creates new wrapper instance for SQL Server command using given Stored Procedure name.
        /// </summary>
        /// <param name="storedProcedure">Stored Procedure name.</param>
        /// <returns>Wrapper instance for SqlCommand</returns>
        public DatabaseCommand CreateStoredProcedureCommand(string storedProcedure)
        {
            var command = new DatabaseCommand();

            command.Initialize(Connection, CommandType.StoredProcedure, storedProcedure);

            return command;
        } 

        #endregion
    }
}
