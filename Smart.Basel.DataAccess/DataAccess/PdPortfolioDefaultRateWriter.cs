﻿using Smart.Basel.DataAccess.Models;
using Smart.Constants;
using Smart.DataAccessWrapper;
using System.Threading.Tasks;

namespace Smart.Basel.DataAccess.DataAccess
{
    /// <summary>
    /// Provides access to all Database Write operations needed for BASEL - PD - Portfolio Default Rate.
    /// </summary>
    internal class PdPortfolioDefaultRateWriter
    {
        #region Public Methods

        /// <summary>
        /// Asynchronously inserts the record.
        /// </summary>
        /// <param name="newRecord">The new record.</param>
        /// <returns>Void Task reference</returns>
        public async Task InsertRecordAsync(PdPortfolioDefaultRate newRecord)
        {
            DatabaseWrapper database = new DatabaseWrapper();
            database.InitializeWithConfigurationFile(ApplicationConstants.CONNECTION_STRING_NAME);
            await database.CreateStoredProcedureCommand(BaselDataAccessConstants.SP_ADD_PD_PORTFOLIO_DEFAULT_RATE)
                .AddParameter(BaselDataAccessConstants.PARAM_PERIOD_END_DATE, newRecord.PeriodEndDate)
                .AddParameter(BaselDataAccessConstants.PARAM_ASSET_SUB_CLASS, newRecord.AssetSubClass)
                .AddParameter(BaselDataAccessConstants.PARAM_NUMBER_OF_ACCOUNTS, newRecord.NumberOfAccounts)
                .AddParameter(BaselDataAccessConstants.PARAM_NUMBER_OF_DEFAULTS, newRecord.NumberOfDefaults)
                .AddParameter(BaselDataAccessConstants.PARAM_DEFAULT_RATE, newRecord.DefaultRate)
                .NonQueryAsync();
        }

        #endregion
    }
}
