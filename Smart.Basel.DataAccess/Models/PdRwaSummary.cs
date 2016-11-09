using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - PD - RWA Summary: Single record holding entity.
    /// </summary>
    public class PdRwaSummary
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
        /// Gets or sets the name of the segment.
        /// </summary>
        /// <value>
        /// The name of the segment.
        /// </value>
        public string SegmentName { get; set; }

        /// <summary>
        /// Gets or sets the total RWA.
        /// </summary>
        /// <value>
        /// The total RWA.
        /// </value>
        public decimal TotalRwa { get; set; }

        #endregion
    }
}
