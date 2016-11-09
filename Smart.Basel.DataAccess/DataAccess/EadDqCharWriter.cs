using Smart.Basel.DataAccess.Models;
using Smart.Constants;
using Smart.DataAccessWrapper;
using System.Threading.Tasks;

namespace Smart.Basel.DataAccess.DataAccess
{
    /// <summary>
    /// Provides access to all Database Write operations needed for BASEL - EAD - Delinquent (Character).
    /// </summary>
    internal class EadDqCharWriter
    {
        #region Public Methods

        /// <summary>
        /// Asynchronously inserts the record.
        /// </summary>
        /// <param name="newRecord">The new record.</param>
        /// <returns>Void Task reference</returns>
        public async Task InsertRecordAsync(EadDqChar newRecord)
        {
            DatabaseWrapper database = new DatabaseWrapper();
            database.InitializeWithConfigurationFile(ApplicationConstants.CONNECTION_STRING_NAME);
            await database.CreateStoredProcedureCommand(BaselDataAccessConstants.SP_ADD_EAD_DQ_CHAR)
                .AddParameter(BaselDataAccessConstants.PARAM_VARIABLE_NAME, newRecord.VariableName)
                .AddParameter(BaselDataAccessConstants.PARAM_COUNT_ALL, newRecord.CountAll)
                .AddParameter(BaselDataAccessConstants.PARAM_COUNT_MISSING, newRecord.CountMissing)
                .AddParameter(BaselDataAccessConstants.PARAM_PERIOD_END_DATE, newRecord.PeriodEndDate)
                .AddParameter(BaselDataAccessConstants.PARAM_PERCENTAGE_MISSING, newRecord.PercentageMissing)
                .NonQueryAsync();
        }

        #endregion
    }
}
