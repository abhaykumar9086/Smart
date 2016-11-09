using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - PD - Combined Output: Single record holding entity.
    /// </summary>
    public class PdCombinedOutput
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
        /// Gets or sets the segment name.
        /// </summary>
        /// <value>
        /// The segment name.
        /// </value>
        public string SegmentName { get; set; }

        /// <summary>
        /// Gets or sets the KS score.
        /// </summary>
        /// <value>
        /// The KS score.
        /// </value>
        public decimal KsScore { get; set; }

        /// <summary>
        /// Gets or sets the GINI score.
        /// </summary>
        /// <value>
        /// The GINI score.
        /// </value>
        public decimal GiniScore { get; set; }

        #endregion
    }
}
