using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - EAD - Delinquent (Numeric): Single record holding entity.
    /// </summary>
    public class EadDqNum
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the variable.
        /// </summary>
        /// <value>
        /// The name of the variable.
        /// </value>
        public string VariableName { get; set; }

        /// <summary>
        /// Gets or sets the value for total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public long CountAll { get; set; }

        /// <summary>
        /// Gets or sets the counts missing.
        /// </summary>
        /// <value>
        /// The counts missing.
        /// </value>
        public long CountMissing { get; set; }

        /// <summary>
        /// Gets or sets the period end date.
        /// </summary>
        /// <value>
        /// The period end date.
        /// </value>
        public DateTime PeriodEndDate { get; set; }

        /// <summary>
        /// Gets or sets the value for percentage missing.
        /// </summary>
        /// <value>
        /// The value for percentage missing.
        /// </value>
        public decimal PercentageMissing { get; set; }

        #endregion
    }
}
