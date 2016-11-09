﻿using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - PD - Balance Summary: Single record holding entity.
    /// </summary>
    public class PdBalanceSummary
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
        /// Gets or sets the exposure value.
        /// </summary>
        /// <value>
        /// The exposure value.
        /// </value>
        public long Exposure { get; set; }

        #endregion
    }
}
