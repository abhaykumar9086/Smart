using Smart.Basel.DataAccess.Models;
using Smart.Constants;
using Smart.DataAccessWrapper;
using System.Threading.Tasks;

namespace Smart.Basel.DataAccess.DataAccess
{
    /// <summary>
    /// Provides access to all Database Write operations needed for BASEL - EAD - Accuracy.
    /// </summary>
    internal class EadAccuracyWriter
    {
        #region Public Methods

        /// <summary>
        /// Asynchronously inserts the record.
        /// </summary>
        /// <param name="newRecord">The new record.</param>
        /// <returns>Void Task reference</returns>
        public async Task InsertRecordAsync(EadAccuracy newRecord)
        {
            DatabaseWrapper database = new DatabaseWrapper();
            database.InitializeWithConfigurationFile(ApplicationConstants.CONNECTION_STRING_NAME);
            await database.CreateStoredProcedureCommand(BaselDataAccessConstants.SP_ADD_EAD_ACCURACY)
                .AddParameter(BaselDataAccessConstants.PARAM_PERIOD_END_DATE, newRecord.PeriodEndDate)
                .AddParameter(BaselDataAccessConstants.PARAM_ASSET_SUB_CLASS, newRecord.AssetSubClass)
                .AddParameter(BaselDataAccessConstants.PARAM_EAD_PRODUCT_SEGMENT, newRecord.EadProductSegment)
                .AddParameter(BaselDataAccessConstants.PARAM_EAD, newRecord.Ead)
                .AddParameter(BaselDataAccessConstants.PARAM_ACTUAL_EAD, newRecord.ActualEad)
                .NonQueryAsync();
        }

        #endregion
    }
}
