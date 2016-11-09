using Smart.Basel.DataAccess.Models;
using Smart.Constants;
using Smart.DataAccessWrapper;
using System.Threading.Tasks;

namespace Smart.Basel.DataAccess.DataAccess
{
    /// <summary>
    /// Provides access to all Database Write operations needed for BASEL - LGD - Accuracy.
    /// </summary>
    internal class LgdAccuracyWriter
    {
        #region Public Methods

        /// <summary>
        /// Asynchronously inserts the record.
        /// </summary>
        /// <param name="newRecord">The new record.</param>
        /// <returns>Void Task reference</returns>
        public async Task InsertRecordAsync(LgdAccuracy newRecord)
        {
            DatabaseWrapper database = new DatabaseWrapper();
            database.InitializeWithConfigurationFile(ApplicationConstants.CONNECTION_STRING_NAME);
            await database.CreateStoredProcedureCommand(BaselDataAccessConstants.SP_ADD_LGD_ACCURACY)
                .AddParameter(BaselDataAccessConstants.PARAM_PERIOD_END_DATE, newRecord.PeriodEndDate)
                .AddParameter(BaselDataAccessConstants.PARAM_LGD_PRODUCT_SEGMENT, newRecord.LgdProductSegment)
                .AddParameter(BaselDataAccessConstants.PARAM_COUNT, newRecord.Count)
                .AddParameter(BaselDataAccessConstants.PARAM_PREDICTED_LGD, newRecord.PredictedLgd)
                .AddParameter(BaselDataAccessConstants.PARAM_ACTUAL_LGD, newRecord.ActualLgd)
                .NonQueryAsync();
        }

        #endregion
    }
}
