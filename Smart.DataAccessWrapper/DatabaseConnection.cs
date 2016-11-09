using Smart.Constants;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Smart.DataAccessWrapper
{
    /// <summary>
    /// Represents custom wrapper class used for interacting with SQL Server Connection. 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class DatabaseConnection : IDisposable
    {
        #region Private Fields

        /// <summary>
        /// Represents object to hold reference for SQL Server Connection.
        /// </summary>
        private SqlConnection connection;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is initialized; otherwise, <c>false</c>.
        /// </value>
        public bool IsInitialized { get; private set; } = false;

        /// <summary>
        /// Gets the connection string value.
        /// </summary>
        /// <value>
        /// The connection string value.
        /// </value>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Gets the Connection State.
        /// </summary>
        /// <value>
        /// The connection state.
        /// </value>
        public ConnectionState State { get { return connection.State; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the specified connection string using specified connection string value.
        /// </summary>
        /// <param name="connectionString">The connection string value.</param>
        /// <exception cref="System.ArgumentException">Cannot create SQL Server connection using the specified Connection String specification.</exception>
        public void Initialize(string connectionString)
        {
            connection = new SqlConnection(connectionString);

            if (connection == null)
            {
                throw new ArgumentException(DataAccessWrapperConstants.EXCEPTION_MESSAGE_CANNOT_CREATE_CONNECTION);
            }

            ConnectionString = connectionString;

            IsInitialized = connection != null
                && !string.IsNullOrEmpty(connection.ConnectionString);
        }

        /// <summary>
        /// Creates a new instance to store reference for SQL Server Command.
        /// </summary>
        /// <returns>SqlCommand object</returns>
        /// <exception cref="System.ArgumentException">Cannot create SqlCommand. SqlCommand creation requires initialized connection with connection string.</exception>
        public SqlCommand CreateCommand()
        {
            if (!IsInitialized)
            {
                throw new ArgumentException(DataAccessWrapperConstants.EXCEPTION_MESSAGE_CANNOT_CREATE_COMMAND);
            }

            var command = connection.CreateCommand();

            return command;
        }

        /// <summary>
        /// Opens the asynchronous.
        /// </summary>
        /// <returns>Asynchronous void Task</returns>
        /// <exception cref="System.ArgumentException">Cannot open a connection to SQL Server. Opening connection to SQL Server requires initialized connection with connection string.</exception>
        public async Task OpenAsync()
        {
            if (!IsInitialized)
            {
                throw new ArgumentException(DataAccessWrapperConstants.EXCEPTION_MESSAGE_CANNOT_OPEN_CONNECTION);
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Closes connection to Database.
        /// </summary>
        public void Close()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region IDisposable Interface Implementations

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            Close();

            if (disposing)
            {
                connection = null;
            }
        }

        #endregion
    }
}
