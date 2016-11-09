using Smart.Basel.DataAccess.Models;
using Smart.Constants;
using Smart.DataAccessWrapper;
using System.Threading.Tasks;

namespace Smart.Basel.DataAccess.DataAccess
{
    /// <summary>
    /// Provides access to all Database Write operations needed for BASEL - PD - Balance Summary.
    /// </summary>
    internal class PdCsiWriter
    {
        #region Public Methods

        /// <summary>
        /// Asynchronously inserts the record.
        /// </summary>
        /// <param name="newRecord">The new record.</param>
        /// <returns>Void Task reference</returns>
        public async Task InsertRecordAsync(PdCsi newRecord)
        {
            DatabaseWrapper database = new DatabaseWrapper();
            database.InitializeWithConfigurationFile(ApplicationConstants.CONNECTION_STRING_NAME);
            await database.CreateStoredProcedureCommand(BaselDataAccessConstants.SP_ADD_PD_CSI)
                .AddParameter(BaselDataAccessConstants.PARAM_VARIABLE_NAME, newRecord.VariableName)
                .AddParameter(BaselDataAccessConstants.PARAM_CATEGORY, newRecord.Category)
                .AddParameter(BaselDataAccessConstants.PARAM_DEV_COUNT, newRecord.DevCount)
                .AddParameter(BaselDataAccessConstants.PARAM_DEV_PERCENTAGE, newRecord.DevPercentage)
                .AddParameter(BaselDataAccessConstants.PARAM_VALIDATION_COUNT, newRecord.ValidationCount)
                .AddParameter(BaselDataAccessConstants.PARAM_VALIDATION_PERCENTAGE, newRecord.ValidationPercentage)
                .AddParameter(BaselDataAccessConstants.PARAM_CSI, newRecord.Csi)
                .AddParameter(BaselDataAccessConstants.PARAM_PRODUCT, newRecord.Product)
                .AddParameter(BaselDataAccessConstants.PARAM_PERIOD_END_DATE, newRecord.PeriodEndDate)
                .NonQueryAsync();
        }

        #endregion
    }
}
