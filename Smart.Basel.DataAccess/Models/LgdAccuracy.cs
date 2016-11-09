using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - LGD - Accuracy: Single record holding entity.
    /// </summary>
    public class LgdAccuracy
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
        /// The segment count.
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

        #endregion
    }
}
