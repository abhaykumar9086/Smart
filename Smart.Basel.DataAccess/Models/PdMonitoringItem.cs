using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - PD - Monitoring Item: Single record holding entity.
    /// </summary>
    public class PdMonitoringItem
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
        /// Gets or sets the segment name.
        /// </summary>
        /// <value>
        /// The segment name.
        /// </value>
        public string SegmentName { get; set; }

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
        /// Gets or sets the number of LRA PD 1.
        /// </summary>
        /// <value>
        /// The number of LRA PD 1.
        /// </value>
        public decimal LraPd1 { get; set; }

        /// <summary>
        /// Gets or sets the number of PIT PD 1.
        /// </summary>
        /// <value>
        /// The number of PIT PD 1.
        /// </value>
        public decimal PitPd1 { get; set; }

        /// <summary>
        /// Gets or sets the actual default rate.
        /// </summary>
        /// <value>
        /// The actual default rate.
        /// </value>
        public decimal ActualDefaultRate { get; set; }

        #endregion
    }
}
