using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - EAD - Accuracy: Single record holding entity.
    /// </summary>
    public class EadAccuracy
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
        /// Gets or sets the EAD Product Segment.
        /// </summary>
        /// <value>
        /// The name of EAD Product Segment.
        /// </value>
        public string EadProductSegment { get; set; }

        /// <summary>
        /// Gets or sets the EAD Value.
        /// </summary>
        /// <value>
        /// The EAD Value.
        /// </value>
        public decimal Ead { get; set; }

        /// <summary>
        /// Gets or sets the actual EAD Value.
        /// </summary>
        /// <value>
        /// The actual EAD Value.
        /// </value>
        public decimal ActualEad { get; set; }

        #endregion
    }
}
