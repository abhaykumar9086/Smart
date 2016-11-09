namespace Smart.Basel.DataAccess.Models
{
    /// <summary>
    /// BASEL - PD - KS Calculation: Single record holding entity.
    /// </summary>
    public class PdKsCalculation
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the asset sub class.
        /// </summary>
        /// <value>
        /// The asset sub class.
        /// </value>
        public string AssetSubClass { get; set; }

        /// <summary>
        /// Gets or sets the name of the segment.
        /// </summary>
        /// <value>
        /// The name of the segment.
        /// </value>
        public string SegmentName { get; set; }

        /// <summary>
        /// Gets or sets the LRA PD Band Name.
        /// </summary>
        /// <value>
        /// The LRA PD Band Name.
        /// </value>
        public string LraPdBand { get; set; }

        /// <summary>
        /// Gets or sets the minimum LRA PD.
        /// </summary>
        /// <value>
        /// The minimum LRA PD.
        /// </value>
        public decimal MinLraPd { get; set; }

        /// <summary>
        /// Gets or sets the maximum LRA PD.
        /// </summary>
        /// <value>
        /// The maximum LRA PD.
        /// </value>
        public decimal MaxLraPd { get; set; }

        /// <summary>
        /// Gets or sets the average LRA PD.
        /// </summary>
        /// <value>
        /// The average LRA PD.
        /// </value>
        public decimal AvgLraPd { get; set; }

        /// <summary>
        /// Gets or sets the nobs.
        /// </summary>
        /// <value>
        /// The nobs.
        /// </value>
        public int Nobs { get; set; }

        /// <summary>
        /// Gets or sets the ndefs.
        /// </summary>
        /// <value>
        /// The ndefs.
        /// </value>
        public int Ndefs { get; set; }

        /// <summary>
        /// Gets or sets the nnon defs.
        /// </summary>
        /// <value>
        /// The nnon defs.
        /// </value>
        public int NnonDefs { get; set; }

        /// <summary>
        /// Gets or sets the obs definition rt.
        /// </summary>
        /// <value>
        /// The obs definition rt.
        /// </value>
        public decimal ObsDefRt { get; set; }

        /// <summary>
        /// Gets or sets the cum definition.
        /// </summary>
        /// <value>
        /// The cum definition.
        /// </value>
        public int CumDef { get; set; }

        /// <summary>
        /// Gets or sets the cum ndef.
        /// </summary>
        /// <value>
        /// The cum ndef.
        /// </value>
        public int CumNdef { get; set; }

        /// <summary>
        /// Gets or sets the total definition.
        /// </summary>
        /// <value>
        /// The total definition.
        /// </value>
        public int TotalDef { get; set; }

        /// <summary>
        /// Gets or sets the total ndef.
        /// </summary>
        /// <value>
        /// The total ndef.
        /// </value>
        public int TotalNdef { get; set; }

        /// <summary>
        /// Gets or sets the cum definition rt.
        /// </summary>
        /// <value>
        /// The cum definition rt.
        /// </value>
        public int CumDefRt { get; set; }

        /// <summary>
        /// Gets or sets the cum ndef rt.
        /// </summary>
        /// <value>
        /// The cum ndef rt.
        /// </value>
        public int CumNdefRt { get; set; }

        /// <summary>
        /// Gets or sets the ks contri.
        /// </summary>
        /// <value>
        /// The ks contri.
        /// </value>
        public decimal KsContri { get; set; }

        #endregion
    }
}
