using Smart.Basel.DataAccess.Models;
using Smart.Constants;
using Smart.DataAccessWrapper;
using System.Threading.Tasks;

namespace Smart.Basel.DataAccess.DataAccess
{
    /// <summary>
    /// Provides access to all Database Write operations needed for BASEL - PD - Combined Output.
    /// </summary>
    internal class PdCombinedOutputWriter
    {
        #region Public Methods

        /// <summary>
        /// Asynchronously inserts the record.
        /// </summary>
        /// <param name="newRecord">The new record.</param>
        /// <returns>Void Task reference</returns>
        public async Task InsertRecordAsync(PdCombinedOutput newRecord)
        {
            DatabaseWrapper database = new DatabaseWrapper();
            database.InitializeWithConfigurationFile(ApplicationConstants.CONNECTION_STRING_NAME);
            await database.CreateStoredProcedureCommand(BaselDataAccessConstants.SP_ADD_PD_COMBINED_OUTPUT)
                .AddParameter(BaselDataAccessConstants.PARAM_PERIOD_END_DATE, newRecord.PeriodEndDate)
                .AddParameter(BaselDataAccessConstants.PARAM_SEGMENT_NAME, newRecord.SegmentName)
                .AddParameter(BaselDataAccessConstants.PARAM_KS_SCORE, newRecord.KsScore)
                .AddParameter(BaselDataAccessConstants.PARAM_GINI_SCORE, newRecord.GiniScore)
                .NonQueryAsync();
        }

        #endregion
    }
}
