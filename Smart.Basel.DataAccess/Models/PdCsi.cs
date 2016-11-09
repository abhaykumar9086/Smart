using System;

namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - PD - CSI: Single record holding entity.
    /// </summary>
    public class PdCsi
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Variable name.
        /// </summary>
        /// <value>
        /// The variable name.
        /// </value>
        public string VariableName { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public decimal Category { get; set; }

        /// <summary>
        /// Gets or sets the dev count.
        /// </summary>
        /// <value>
        /// The dev count.
        /// </value>
        public string DevCount { get; set; }

        /// <summary>
        /// Gets or sets the dev percentage.
        /// </summary>
        /// <value>
        /// The dev percentage.
        /// </value>
        public decimal DevPercentage { get; set; }

        /// <summary>
        /// Gets or sets the validation count.
        /// </summary>
        /// <value>
        /// The validation count.
        /// </value>
        public string ValidationCount { get; set; }

        /// <summary>
        /// Gets or sets the validation percentage.
        /// </summary>
        /// <value>
        /// The validation percentage.
        /// </value>
        public decimal ValidationPercentage { get; set; }

        /// <summary>
        /// Gets or sets the CSI.
        /// </summary>
        /// <value>
        /// The CSI.
        /// </value>
        public decimal Csi { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the period end date.
        /// </summary>
        /// <value>
        /// The period end date.
        /// </value>
        public DateTime PeriodEndDate { get; set; }

        #endregion
    }
}
