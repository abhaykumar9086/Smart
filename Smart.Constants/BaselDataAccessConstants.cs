namespace Smart.Constants
{
    /// <summary>
    /// Constant string references used for BASEL Data Access Wrapper Library.
    /// </summary>
    public sealed class BaselDataAccessConstants
    {
        #region Stored Procedure Names

        /// <summary>
        /// The Stored Procedure named Add_EadAccuracy.
        /// </summary>
        public const string SP_ADD_EAD_ACCURACY = "Add_EadAccuracy";

        /// <summary>
        /// The Stored Procedure named Add_EadDqChar.
        /// </summary>
        public const string SP_ADD_EAD_DQ_CHAR = "Add_EadDqChar";

        /// <summary>
        /// The Stored Procedure named Add_EadDqNum.
        /// </summary>
        public const string SP_ADD_EAD_DQ_NUM = "Add_EadDqNum";

        /// <summary>
        /// The Stored Procedure named Add_EadPsi.
        /// </summary>
        public const string SP_ADD_EAD_PSI = "Add_EadPsi";

        /// <summary>
        /// The Stored Procedure named Add_LgdAccuracy.
        /// </summary>
        public const string SP_ADD_LGD_ACCURACY = "Add_LgdAccuracy";

        /// <summary>
        /// The Stored Procedure named Add_LgdDqChar.
        /// </summary>
        public const string SP_ADD_LGD_DQ_CHAR = "Add_LgdDqChar";

        /// <summary>
        /// The Stored Procedure named Add_LgdDqNum.
        /// </summary>
        public const string SP_ADD_LGD_DQ_NUM = "Add_LgdDqNum";

        /// <summary>
        /// The Stored Procedure named Add_LgdLossShortfall.
        /// </summary>
        public const string SP_ADD_LGD_LOSS_SHORTFALL = "Add_LgdLossShortfall";

        /// <summary>
        /// The Stored Procedure named Add_PdBalanceSummary.
        /// </summary>
        public const string SP_ADD_PD_BALANCE_SUMMARY = "Add_PdBalanceSummary";

        /// <summary>
        /// The Stored Procedure named Add_PdCombinedOutput.
        /// </summary>
        public const string SP_ADD_PD_COMBINED_OUTPUT = "Add_PdCombinedOutput";

        /// <summary>
        /// The Stored Procedure named Add_PdCsi.
        /// </summary>
        public const string SP_ADD_PD_CSI = "Add_PdCsi";

        /// <summary>
        /// The Stored Procedure named Add_PdCsi.
        /// </summary>
        public const string SP_ADD_PD_KS_CALCULATION = "Add_PdKsCalculation";

        /// <summary>
        /// The Stored Procedure named Add_PdMonitoringItem.
        /// </summary>
        public const string SP_ADD_PD_MONITORING_ITEM = "Add_PdMonitoringItem";

        /// <summary>
        /// The Stored Procedure named Add_PdPortfolioDefaultRate.
        /// </summary>
        public const string SP_ADD_PD_PORTFOLIO_DEFAULT_RATE = "Add_PdPortfolioDefaultRate";

        /// <summary>
        /// The Stored Procedure named Add_PdPsi.
        /// </summary>
        public const string SP_ADD_PD_PSI = "Add_PdPsi";

        /// <summary>
        /// The Stored Procedure named Add_PdRwaSummary.
        /// </summary>
        public const string SP_ADD_PD_RWA_SUMMARY = "Add_PdRwaSummary";

        /// <summary>
        /// The Stored Procedure named Add_PdDqChar.
        /// </summary>
        public const string SP_ADD_PD_DQ_CHAR = "Add_PdDqChar";

        /// <summary>
        /// The Stored Procedure named Add_PdDqNum.
        /// </summary>
        public const string SP_ADD_PD_DQ_NUM = "Add_PdDqNum";

        #endregion

        #region Stored Procedure Parameters

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @VariableName.
        /// </summary>
        public const string PARAM_VARIABLE_NAME = "@VariableName";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @CountAll.
        /// </summary>
        public const string PARAM_COUNT_ALL = "@CountAll";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @CountMissing.
        /// </summary>
        public const string PARAM_COUNT_MISSING = "@CountMissing";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @PeriodEndDate.
        /// </summary>
        public const string PARAM_PERIOD_END_DATE = "@PeriodEndDate";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @PercentageMissing.
        /// </summary>
        public const string PARAM_PERCENTAGE_MISSING = "@PercentageMissing";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @NumberOfAccounts.
        /// </summary>
        public const string PARAM_NUMBER_OF_ACCOUNTS = "@NumberOfAccounts";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @Ead.
        /// </summary>
        public const string PARAM_EAD = "@Ead";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @ActualEad.
        /// </summary>
        public const string PARAM_ACTUAL_EAD = "@ActualEad";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @SegmentName.
        /// </summary>
        public const string PARAM_SEGMENT_NAME = "@SegmentName";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @Exposure.
        /// </summary>
        public const string PARAM_EXPOSURE = "@Exposure";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @SegmentCounts.
        /// </summary>
        public const string PARAM_SEGMENT_COUNTS = "@SegmentCounts";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @ActualLgd.
        /// </summary>
        public const string PARAM_SEGMENT_ACTUAL_LGD = "@ActualLgd";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @Count.
        /// </summary>
        public const string PARAM_COUNT = "@Count";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @PredictedLgd.
        /// </summary>
        public const string PARAM_PREDICTED_LGD = "@PredictedLgd";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @ActualLgd.
        /// </summary>
        public const string PARAM_ACTUAL_LGD = "@ActualLgd";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @AssetSubClass.
        /// </summary>
        public const string PARAM_ASSET_SUB_CLASS = "@AssetSubClass";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @EadProductSegment.
        /// </summary>
        public const string PARAM_EAD_PRODUCT_SEGMENT = "@EadProductSegment";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @LgdProductSegment.
        /// </summary>
        public const string PARAM_LGD_PRODUCT_SEGMENT = "@LgdProductSegment";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @Category.
        /// </summary>
        public const string PARAM_CATEGORY = "@Category";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @DevCount.
        /// </summary>
        public const string PARAM_DEV_COUNT = "@DevCount";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @DevPercentage.
        /// </summary>
        public const string PARAM_DEV_PERCENTAGE = "@DevPercentage";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @ValidationCount.
        /// </summary>
        public const string PARAM_VALIDATION_COUNT = "@ValidationCount";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @ValidationPercentage.
        /// </summary>
        public const string PARAM_VALIDATION_PERCENTAGE = "@ValidationPercentage";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @Csi.
        /// </summary>
        public const string PARAM_CSI = "@Csi";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @Product.
        /// </summary>
        public const string PARAM_PRODUCT = "@Product";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @KsScore.
        /// </summary>
        public const string PARAM_KS_SCORE = "@KsScore";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @GiniScore.
        /// </summary>
        public const string PARAM_GINI_SCORE = "@GiniScore";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @LraPdBand.
        /// </summary>
        public const string PARAM_LRA_PD_BAND = "@LraPdBand";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @MinLraPd.
        /// </summary>
        public const string PARAM_MIN_LRA_PD = "@MinLraPd";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @MaxLraPd.
        /// </summary>
        public const string PARAM_MAX_LRA_PD = "@MaxLraPd";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @AvgLraPd.
        /// </summary>
        public const string PARAM_AVG_LRA_PD = "@AvgLraPd";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @Nobs.
        /// </summary>
        public const string PARAM_NOBS = "@Nobs";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @Ndefs.
        /// </summary>
        public const string PARAM_NDEFS = "@Ndefs";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @NnonDefs.
        /// </summary>
        public const string PARAM_NNON_DEFS = "@NnonDefs";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @ObsDefRt.
        /// </summary>
        public const string PARAM_OBS_DEF_RT = "@ObsDefRt";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @CumDef.
        /// </summary>
        public const string PARAM_CUM_DEF = "@CumDef";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @CumNdef.
        /// </summary>
        public const string PARAM_CUM_NDEF = "@CumNdef";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @TotalDef.
        /// </summary>
        public const string PARAM_TOTAL_DEF = "@TotalDef";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @TotalNdef.
        /// </summary>
        public const string PARAM_TOTAL_NDEF = "@TotalNdef";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @CumDefRt.
        /// </summary>
        public const string PARAM_CUM_DEF_RT = "@CumDefRt";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @CumNdefRt.
        /// </summary>
        public const string PARAM_CUM_NDEF_RT = "@CumNdefRt";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @KsContri.
        /// </summary>
        public const string PARAM_KS_CONTRI = "@KsContri";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @NumberOfDefaults.
        /// </summary>
        public const string PARAM_NUMBER_OF_DEFAULTS = "@NumberOfDefaults";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @LraPd1.
        /// </summary>
        public const string PARAM_LRA_PD_1 = "@LraPd1";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @PitPd1.
        /// </summary>
        public const string PARAM_PIT_PD_1 = "@PitPd1";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @ActualDefaultRate.
        /// </summary>
        public const string PARAM_ACTUAL_DEFAULT_RATE = "@ActualDefaultRate";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @DefaultRate.
        /// </summary>
        public const string PARAM_DEFAULT_RATE = "@DefaultRate";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @PdProductSegment.
        /// </summary>
        public const string PARAM_PD_PRODUCT_SEGMENT = "@PdProductSegment";

        /// <summary>
        /// The SQL Server Stored Procedure Parameter named @totalRwa.
        /// </summary>
        public const string PARAM_TOTAL_RWA = "@totalRwa";

        #endregion
    }
}
