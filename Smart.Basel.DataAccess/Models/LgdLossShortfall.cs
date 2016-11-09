using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - LGD - Loss Shortfall: Single record holding entity.
    /// </summary>
    public class LgdLossShortfall
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
        /// Gets or sets the LGD Product Segment.
        /// </summary>
        /// <value>
        /// The LGD Product Segment.
        /// </value>
        public string LgdProductSegment { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets the predicted LGD.
        /// </summary>
        /// <value>
        /// The predicted LGD.
        /// </value>
        public decimal PredictedLgd { get; set; }

        /// <summary>
        /// Gets or sets the actual LGD.
        /// </summary>
        /// <value>
        /// The actual LGD.
        /// </value>
        public decimal ActualLgd { get; set; }

        /// <summary>
        /// Gets or sets the actual EAD.
        /// </summary>
        /// <value>
        /// The actual EAD.
        /// </value>
        public decimal ActualEad { get; set; }

        #endregion
    }
}
