using Smart.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Smart.DataAccessWrapper
{
    /// <summary>
    /// Represents custom wrapper class used for interacting with SQL Server Commands. 
    /// Primary use for this is to execute Stored Procedures and Queries in SQL Server.
    /// </summary>
    public class DatabaseCommand
    {
        #region Private Fields

        /// <summary>
        /// Represents instance of Database Connection used to interact with SQL Server connection.
        /// </summary>
        private DatabaseConnection connection;

        /// <summary>
        /// Represents object to hold value of Stored Procedure or Query to be executed.
        /// </summary>
        private SqlCommand command;

        /// <summary>
        /// Represents variable to map to Generic class for reading records.
        /// </summary>
        private IMapper mapper;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether Command is initialized by passing either Stored Procedure Name or Query.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is initialized; otherwise, <c>false</c>.
        /// </value>
        public bool IsInitialized { get; private set; } = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseCommand"/> class.
        /// </summary>
        public DatabaseCommand() : this(Mapper.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseCommand"/> class using Strong Entity Mapper.
        /// </summary>
        /// <param name="mapper">Strong Entity Mapper Reference.</param>
        public DatabaseCommand(IMapper mapper)
        {
            this.mapper = mapper;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates a new parameter with Parameter name and value.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">The value.</param>
        /// <returns>SqlParameter object</returns>
        private SqlParameter CreateParameter(string parameterName, object value)
        {
            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            parameter.Value = value;

            return parameter;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes SQL Server command with connection, Command Type (Stored Procedure or Table) and 
        /// Stored Procedure name or Query Text.
        /// </summary>
        /// <param name="connection">Wrapped SQL Database connection.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">Stored Procedure name or SQL Query.</param>
        /// <exception cref="ArgumentException">Requires an initialized connection.</exception>
        public void Initialize(DatabaseConnection connection, CommandType commandType, string commandText)
        {
            if (!connection.IsInitialized)
            {
                throw new ArgumentException(DataAccessWrapperConstants.EXCEPTION_MESSAGE_REQUIRES_INITIALIZED_CONNECTION);
            }

            this.connection = connection;

            command = this.connection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;

            IsInitialized = command != null
                && command.Connection != null
                && !string.IsNullOrEmpty(command.Connection.ConnectionString);
        }

        /// <summary>
        /// Adds new parameter for current command.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">Value of the parameter.</param>
        /// <returns>Updated Wrapped SQL Command with parameter appended.</returns>
        /// <exception cref="System.ArgumentException">Cannot add parameter. Requires an initialized connection.</exception>
        public DatabaseCommand AddParameter(string parameterName, object value)
        {
            if (!IsInitialized)
            {
                throw new ArgumentException(DataAccessWrapperConstants.EXCEPTION_MESSAGE_ADD_PARAMETER_FAILURE);
            }

            command.Parameters.Add(CreateParameter(parameterName, value));

            return this;
        }

        /// <summary>
        /// Asynchronously reads all records.
        /// </summary>
        /// <typeparam name="T">Class Type representing entity to read records for.</typeparam>
        /// <param name="mapDataToObject">SQL Data Reader reference.</param>
        /// <returns>All records for entity specified as Generic argument.</returns>
        public async Task<IEnumerable<T>> ReadAllAsync<T>(Func<SqlDataReader, T> mapDataToObject)
        {
            var result = new List<T>();

            await connection.OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Add(mapDataToObject(reader));
                }
            }

            connection.Close();

            return result;
        }

        /// <summary>
        /// Asynchronously reads single record.
        /// </summary>
        /// <typeparam name="T">Class Type representing entity to read record for.</typeparam>
        /// <param name="mapDataToObject">SQL Data Reader reference.</param>
        /// <returns>Single record for entity specified as Generic argument.</returns>
        public async Task<T> ReadOneAsync<T>(Func<SqlDataReader, T> mapDataToObject)
        {
            await connection.OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var result = mapDataToObject(reader);
                    return result;
                }
            }

            connection.Close();

            return default(T);
        }

        /// <summary>
        /// Asynchronously maps all records to generic type specified.
        /// </summary>
        /// <typeparam name="T">Class to which record should be typecasted.</typeparam>
        /// <returns>List of records typecasted to Target type specified as Generic class while calling Method.</returns>
        public async Task<IEnumerable<T>> ReadAllMapToAsync<T>()
           where T : class, new()
        {
            return await ReadAllAsync(mapper.MapDataToObject<T>);
        }

        /// <summary>
        /// Asynchronously maps single record to generic type specified.
        /// </summary>
        /// <typeparam name="T">Class to which record should be typecasted.</typeparam>
        /// <returns>Single record typecasted to Target type specified as Generic class while calling Method.</returns>
        public async Task<T> ReadOneMapToAsync<T>()
           where T : class, new()
        {
            return await ReadOneAsync(mapper.MapDataToObject<T>);
        }

        /// <summary>
        /// Asynchronously executes a Transact-SQL statement against the connection 
        /// and returns the number of rows affected.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> NonQueryAsync()
        {
            await connection.OpenAsync();
            int response = await command.ExecuteNonQueryAsync();
            connection.Close();
            return response;
        }

        /// <summary>
        /// Asynchronously executes the query, and returns the first column of the 
        /// first row in the result set returned by the query. 
        /// Additional columns or rows are ignored.
        /// </summary>
        /// <returns>The first column of the first row in the result set, or a null reference 
        /// if the result set is empty. Returns a maximum of 2033 characters.</returns>
        public async Task<object> ScalarAsync()
        {
            await connection.OpenAsync();
            object result = await command.ExecuteScalarAsync();
            connection.Close();
            return result;
        }

        #endregion
    }
}
