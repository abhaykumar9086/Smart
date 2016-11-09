using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - PD - Portfolio Default Rate: Single record holding entity.
    /// </summary>
    public class PdPortfolioDefaultRate
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the period end date.
        /// </summary>
        /// <value>
        /// The period end date.
        /// </value>
        public DateTime PeriodEndDate { get; set; }

        /// <summary>
        /// Gets or sets the Asset Sub Class.
        /// </summary>
        /// <value>
        /// The name of Asset Sub Class.
        /// </value>
        public string AssetSubClass { get; set; }

        /// <summary>
        /// Gets or sets the number of accounts.
        /// </summary>
        /// <value>
        /// The number of accounts.
        /// </value>
        public long NumberOfAccounts { get; set; }

        /// <summary>
        /// Gets or sets the number of defaults.
        /// </summary>
        /// <value>
        /// The number of defaults.
        /// </value>
        public long NumberOfDefaults { get; set; }

        /// <summary>
        /// Gets or sets the Default Rate.
        /// </summary>
        /// <value>
        /// The name of Default Rate.
        /// </value>
        public decimal DefaultRate { get; set; }
        
        #endregion
    }
}
