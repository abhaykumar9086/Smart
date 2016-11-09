using Smart.Basel.DataAccess.Models;
using Smart.Constants;
using Smart.DataAccessWrapper;
using System.Threading.Tasks;

namespace Smart.Basel.DataAccess.DataAccess
{
    /// <summary>
    /// Provides access to all Database Write operations needed for BASEL - LGD - Loss Shortfall.
    /// </summary>
    internal class LgdLossShortfallWriter
    {
        #region Public Methods

        /// <summary>
        /// Asynchronously inserts the record.
        /// </summary>
        /// <param name="newRecord">The new record.</param>
        /// <returns>Void Task reference</returns>
        public async Task InsertRecordAsync(LgdLossShortfall newRecord)
        {
            DatabaseWrapper database = new DatabaseWrapper();
            database.InitializeWithConfigurationFile(ApplicationConstants.CONNECTION_STRING_NAME);
            await database.CreateStoredProcedureCommand(BaselDataAccessConstants.SP_ADD_LGD_LOSS_SHORTFALL)
                .AddParameter(BaselDataAccessConstants.PARAM_PERIOD_END_DATE, newRecord.PeriodEndDate)
                .AddParameter(BaselDataAccessConstants.PARAM_LGD_PRODUCT_SEGMENT, newRecord.LgdProductSegment)
                .AddParameter(BaselDataAccessConstants.PARAM_COUNT, newRecord.Count)
                .AddParameter(BaselDataAccessConstants.PARAM_PREDICTED_LGD, newRecord.PredictedLgd)
                .AddParameter(BaselDataAccessConstants.PARAM_ACTUAL_LGD, newRecord.ActualLgd)
                .AddParameter(BaselDataAccessConstants.PARAM_ACTUAL_EAD, newRecord.ActualEad)
                .NonQueryAsync();
        }

        #endregion
    }
}
