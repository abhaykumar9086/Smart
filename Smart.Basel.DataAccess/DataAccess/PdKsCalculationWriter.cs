using Smart.Basel.DataAccess.Models;
using Smart.Constants;
using Smart.DataAccessWrapper;
using System.Threading.Tasks;

namespace Smart.Basel.DataAccess.DataAccess
{
    /// <summary>
    /// Provides access to all Database Write operations needed for BASEL - PD - KS Calculation.
    /// </summary>
    internal class PdKsCalculationWriter
    {
        #region Public Methods

        /// <summary>
        /// Asynchronously inserts the record.
        /// </summary>
        /// <param name="newRecord">The new record.</param>
        /// <returns>Void Task reference</returns>
        public async Task InsertRecordAsync(PdKsCalculation newRecord)
        {
            DatabaseWrapper database = new DatabaseWrapper();
            database.InitializeWithConfigurationFile(ApplicationConstants.CONNECTION_STRING_NAME);
            await database.CreateStoredProcedureCommand(BaselDataAccessConstants.SP_ADD_PD_KS_CALCULATION)
                .AddParameter(BaselDataAccessConstants.PARAM_ASSET_SUB_CLASS, newRecord.AssetSubClass)
                .AddParameter(BaselDataAccessConstants.PARAM_SEGMENT_NAME, newRecord.SegmentName)
                .AddParameter(BaselDataAccessConstants.PARAM_LRA_PD_BAND, newRecord.LraPdBand)
                .AddParameter(BaselDataAccessConstants.PARAM_MIN_LRA_PD, newRecord.MinLraPd)
                .AddParameter(BaselDataAccessConstants.PARAM_MAX_LRA_PD, newRecord.MaxLraPd)
                .AddParameter(BaselDataAccessConstants.PARAM_AVG_LRA_PD, newRecord.AvgLraPd)
                .AddParameter(BaselDataAccessConstants.PARAM_NOBS, newRecord.Nobs)
                .AddParameter(BaselDataAccessConstants.PARAM_NDEFS, newRecord.Ndefs)
                .AddParameter(BaselDataAccessConstants.PARAM_NNON_DEFS, newRecord.NnonDefs)
                .AddParameter(BaselDataAccessConstants.PARAM_OBS_DEF_RT, newRecord.ObsDefRt)
                .AddParameter(BaselDataAccessConstants.PARAM_CUM_DEF, newRecord.CumDef)
                .AddParameter(BaselDataAccessConstants.PARAM_CUM_NDEF, newRecord.CumNdef)
                .AddParameter(BaselDataAccessConstants.PARAM_TOTAL_DEF, newRecord.TotalDef)
                .AddParameter(BaselDataAccessConstants.PARAM_TOTAL_NDEF, newRecord.TotalNdef)
                .AddParameter(BaselDataAccessConstants.PARAM_CUM_DEF_RT, newRecord.CumDefRt)
                .AddParameter(BaselDataAccessConstants.PARAM_CUM_NDEF_RT, newRecord.CumNdefRt)
                .AddParameter(BaselDataAccessConstants.PARAM_KS_CONTRI, newRecord.KsContri)
                .NonQueryAsync();
        }

        #endregion
    }
}
