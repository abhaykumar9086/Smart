using Microsoft.VisualBasic.FileIO;
using Smart.Basel.DataAccess.BusinessObjects;
using Smart.Basel.DataAccess.Models;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Telerik.Web.UI;

namespace Smart.WebApp.CurrentGen
{
    /// <summary>
    /// Test Page to show importing multiple files for BASEL Portfolios. Tested with inputs of CARDS Portfolio.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the FileUploaded event of the AsyncUpload1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FileUploadedEventArgs"/> instance containing the event data.</param>
        protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            lblTest.Text += e.File.FileName + "<BR />" + ((FileStream)e.File.InputStream).Name + "<BR />";

            if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_EAD_ACCURACY], RegexOptions.IgnoreCase).Success)
            {
                ImportEadAccuracy(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_EAD_DQ_CHAR], RegexOptions.IgnoreCase).Success)
            {
                ImportEadDqChar(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_EAD_DQ_NUM], RegexOptions.IgnoreCase).Success)
            {
                ImportEadDqNum(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_EAD_PSI], RegexOptions.IgnoreCase).Success)
            {
                ImportEadPsi(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_LGD_ACCURACY], RegexOptions.IgnoreCase).Success)
            {
                ImportLgdAccuracy(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_LGD_DQ_CHAR], RegexOptions.IgnoreCase).Success)
            {
                ImportLgdDqChar(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_LGD_DQ_NUM], RegexOptions.IgnoreCase).Success)
            {
                ImportLgdDqNum(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_LGD_LOSS_SHORTFALL], RegexOptions.IgnoreCase).Success)
            {
                ImportLgdLossShortfall(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_BALANCE_SUMMARY], RegexOptions.IgnoreCase).Success)
            {
                ImportPdBalanceSummary(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_COMBINED_OUTPUT], RegexOptions.IgnoreCase).Success)
            {
                ImportPdCombinedOutput(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_CSI], RegexOptions.IgnoreCase).Success)
            {
                ImportPdCsi(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_DQ_CHAR], RegexOptions.IgnoreCase).Success)
            {
                ImportPdDqChar(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_DQ_NUM], RegexOptions.IgnoreCase).Success)
            {
                ImportPdDqNum(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_KS_CALCULATION], RegexOptions.IgnoreCase).Success)
            {
                ImportPdKsCalculation(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_MONITORING_ITEM], RegexOptions.IgnoreCase).Success)
            {
                ImportPdMonitoringItem(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_PORTFOLIO_DEFAULT_RATE], RegexOptions.IgnoreCase).Success)
            {
                ImportPdPortfolioDefaultRate(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_PSI], RegexOptions.IgnoreCase).Success)
            {
                ImportPdPsi(e.File.InputStream);
            }
            else if (Regex.Match(e.File.FileName, ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_REG_EX_PD_RWA_SUMMARY], RegexOptions.IgnoreCase).Success)
            {
                ImportPdRwaSummary(e.File.InputStream);
            }
        }

        /// <summary>
        /// Imports the data file for EAD Accuracy.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportEadAccuracy(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    EadAccuracy newRecord = new EadAccuracy();
                    newRecord.PeriodEndDate = DateTime.ParseExact(
                        fields[0],
                        ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_IMPORT_DATE_FORMAT],
                        CultureInfo.InvariantCulture);
                    newRecord.AssetSubClass = fields[1];
                    newRecord.EadProductSegment = fields[2];
                    newRecord.Ead = Decimal.Parse(fields[3], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    newRecord.ActualEad = Decimal.Parse(fields[4], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new EadAccuracyManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for EAD DQ (Characters).
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportEadDqChar(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    EadDqChar newRecord = new EadDqChar();
                    newRecord.VariableName = fields[0];
                    newRecord.CountAll = Convert.ToInt64(fields[1]);
                    newRecord.CountMissing = Convert.ToInt64(fields[2]);
                    newRecord.PeriodEndDate = new DateTime(
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(0, 4))
                            ),
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(4, 2))
                            ),
                        1
                       ).AddMonths(1).AddDays(-1);
                    newRecord.PercentageMissing = Decimal.Parse(fields[4], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new EadDqCharManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for EAD DQ (Numbers).
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportEadDqNum(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    EadDqNum newRecord = new EadDqNum();
                    newRecord.VariableName = fields[0];
                    newRecord.CountAll = Convert.ToInt64(fields[1]);
                    newRecord.CountMissing = Convert.ToInt64(fields[2]);
                    newRecord.PeriodEndDate = new DateTime(
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(0, 4))
                            ),
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(4, 2))
                            ),
                        1
                       ).AddMonths(1).AddDays(-1);
                    newRecord.PercentageMissing = Decimal.Parse(fields[4], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    await (new EadDqNumManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for EAD PSI.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportEadPsi(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    EadPsi newRecord = new EadPsi();
                    newRecord.PeriodEndDate = DateTime.ParseExact(
                        fields[0],
                        ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_IMPORT_DATE_FORMAT],
                        CultureInfo.InvariantCulture);
                    newRecord.AssetSubClass = fields[1];
                    newRecord.EadProductSegment = fields[2];
                    newRecord.NumberOfAccounts = Convert.ToInt64(fields[3]);
                    newRecord.Exposure = Convert.ToInt64(fields[4]);

                    await (new EadPsiManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for LGD Accuracy.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportLgdAccuracy(Stream fileData)
        {
            DateTime periodEndDate = new DateTime(
                Convert.ToInt32(
                    Convert.ToInt64(((FileStream)fileData).Name.Substring(((FileStream)fileData).Name.Length - 10, 4))
                    ),
                Convert.ToInt32(
                    Convert.ToInt64(((FileStream)fileData).Name.Substring(((FileStream)fileData).Name.Length - 6, 2))
                    ),
                1
               ).AddMonths(1).AddDays(-1);

            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    LgdAccuracy newRecord = new LgdAccuracy();
                    newRecord.PeriodEndDate = periodEndDate;
                    newRecord.LgdProductSegment = fields[0];
                    newRecord.Count = Convert.ToInt64(fields[1]);
                    newRecord.PredictedLgd = Decimal.Parse(fields[2], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    newRecord.ActualLgd = Decimal.Parse(fields[3], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new LgdAccuracyManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for LGD DQ (Characters).
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportLgdDqChar(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    LgdDqChar newRecord = new LgdDqChar();
                    newRecord.VariableName = fields[0];
                    newRecord.CountAll = Convert.ToInt64(fields[1]);
                    newRecord.CountMissing = Convert.ToInt64(fields[2]);
                    newRecord.PeriodEndDate = new DateTime(
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(0, 4))
                            ),
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(4, 2))
                            ),
                        1
                       ).AddMonths(1).AddDays(-1);
                    newRecord.PercentageMissing = Decimal.Parse(fields[4], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new LgdDqCharManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for LGD DQ (Numbers).
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportLgdDqNum(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    LgdDqNum newRecord = new LgdDqNum();
                    newRecord.VariableName = fields[0];
                    newRecord.CountAll = Convert.ToInt64(fields[1]);
                    newRecord.CountMissing = Convert.ToInt64(fields[2]);
                    newRecord.PeriodEndDate = new DateTime(
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(0, 4))
                            ),
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(4, 2))
                            ),
                        1
                       ).AddMonths(1).AddDays(-1);
                    newRecord.PercentageMissing = Decimal.Parse(fields[4], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new LgdDqNumManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for LGD Loss Shortfall.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportLgdLossShortfall(Stream fileData)
        {
            DateTime periodEndDate = new DateTime(
                Convert.ToInt32(
                    Convert.ToInt64(((FileStream)fileData).Name.Substring(((FileStream)fileData).Name.Length - 10, 4))
                    ),
                Convert.ToInt32(
                    Convert.ToInt64(((FileStream)fileData).Name.Substring(((FileStream)fileData).Name.Length - 6, 2))
                    ),
                1
               ).AddMonths(1).AddDays(-1);

            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    LgdLossShortfall newRecord = new LgdLossShortfall();
                    newRecord.PeriodEndDate = periodEndDate;
                    newRecord.LgdProductSegment = fields[0];
                    newRecord.Count = Convert.ToInt64(fields[1]);
                    newRecord.PredictedLgd = Decimal.Parse(fields[2], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    newRecord.ActualLgd = Decimal.Parse(fields[3], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    newRecord.ActualEad = Decimal.Parse(fields[4], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new LgdLossShortfallManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD Balance Summary.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdBalanceSummary(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdBalanceSummary newRecord = new PdBalanceSummary();
                    newRecord.PeriodEndDate = DateTime.ParseExact(
                        fields[0],
                        ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_IMPORT_DATE_FORMAT],
                        CultureInfo.InvariantCulture);
                    newRecord.AssetSubClass = fields[1];
                    newRecord.NumberOfAccounts = Convert.ToInt64(fields[2]);
                    newRecord.Exposure = Convert.ToInt64(fields[3]);

                    await (new PdBalanceSummaryManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD Combined Output.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdCombinedOutput(Stream fileData)
        {
            DateTime periodEndDate = new DateTime(
                Convert.ToInt32(
                    Convert.ToInt64(((FileStream)fileData).Name.Substring(((FileStream)fileData).Name.Length - 10, 4))
                    ),
                Convert.ToInt32(
                    Convert.ToInt64(((FileStream)fileData).Name.Substring(((FileStream)fileData).Name.Length - 6, 2))
                    ),
                1
               ).AddMonths(1).AddDays(-1);

            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdCombinedOutput newRecord = new PdCombinedOutput();
                    newRecord.PeriodEndDate = periodEndDate;
                    newRecord.SegmentName = fields[0];
                    newRecord.KsScore = Decimal.Parse(fields[1], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    newRecord.GiniScore = Decimal.Parse(fields[2], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new PdCombinedOutputManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD CSI.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdCsi(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdCsi newRecord = new PdCsi();
                    newRecord.VariableName = fields[0];
                    newRecord.Category = Decimal.Parse(fields[1], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    newRecord.DevCount = fields[2];
                    try
                    {
                        newRecord.DevPercentage = Decimal.Parse(fields[3], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                    catch (Exception)
                    {
                        newRecord.DevPercentage = 0;
                    }
                    newRecord.ValidationCount = fields[4];
                    try
                    {
                        newRecord.ValidationPercentage = Decimal.Parse(fields[5], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                    catch (Exception)
                    {
                        newRecord.ValidationPercentage = 0;
                    }
                    try
                    {
                        newRecord.Csi = Decimal.Parse(fields[6], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                    catch (Exception)
                    {
                        newRecord.Csi = 0;
                    }
                    newRecord.Product = fields[7];
                    newRecord.PeriodEndDate = new DateTime(
                        Convert.ToInt32(
                            Convert.ToInt64(fields[8].Substring(0, 4))
                            ),
                        Convert.ToInt32(
                            Convert.ToInt64(fields[8].Substring(4, 2))
                            ),
                        1
                       ).AddMonths(1).AddDays(-1);

                    await (new PdCsiManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD DQ (Characters).
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdDqChar(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdDqChar newRecord = new PdDqChar();
                    newRecord.VariableName = fields[0];
                    newRecord.CountAll = Convert.ToInt64(fields[1]);
                    newRecord.CountMissing = Convert.ToInt64(fields[2]);
                    newRecord.PeriodEndDate = new DateTime(
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(0, 4))
                            ),
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(4, 2))
                            ),
                        1
                       ).AddMonths(1).AddDays(-1);
                    newRecord.PercentageMissing = Decimal.Parse(fields[4], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new PdDqCharManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD DQ (Numbers).
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdDqNum(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdDqNum newRecord = new PdDqNum();
                    newRecord.VariableName = fields[0];
                    newRecord.CountAll = Convert.ToInt64(fields[1]);
                    newRecord.CountMissing = Convert.ToInt64(fields[2]);
                    newRecord.PeriodEndDate = new DateTime(
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(0, 4))
                            ),
                        Convert.ToInt32(
                            Convert.ToInt64(fields[3].Substring(4, 2))
                            ),
                        1
                       ).AddMonths(1).AddDays(-1);
                    newRecord.PercentageMissing = Decimal.Parse(fields[4], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new PdDqNumManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD KS Calculation.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdKsCalculation(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdKsCalculation newRecord = new PdKsCalculation();
                    newRecord.AssetSubClass = fields[0];
                    newRecord.SegmentName = fields[1];
                    newRecord.LraPdBand = fields[2];
                    try
                    {
                        newRecord.MinLraPd = Decimal.Parse(fields[3].Replace("%", ""), NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                    catch (Exception)
                    {
                        newRecord.MinLraPd = 0;
                    }
                    try
                    {
                        newRecord.MaxLraPd = Decimal.Parse(fields[4].Replace("%", ""), NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                    catch (Exception)
                    {
                        newRecord.MaxLraPd = 0;
                    }
                    try
                    {
                        newRecord.AvgLraPd = Decimal.Parse(fields[5].Replace("%", ""), NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                    catch (Exception)
                    {
                        newRecord.AvgLraPd = 0;
                    }
                    try
                    {
                        newRecord.Nobs = Convert.ToInt32(fields[6]);
                    }
                    catch (Exception)
                    {
                        newRecord.Nobs = 0;
                    }
                    try
                    {
                        newRecord.Ndefs = Convert.ToInt32(fields[7]);
                    }
                    catch (Exception)
                    {
                        newRecord.Ndefs = 0;
                    }
                    try
                    {
                        newRecord.NnonDefs = Convert.ToInt32(fields[8]);
                    }
                    catch (Exception)
                    {
                        newRecord.NnonDefs = 0;
                    }
                    try
                    {
                        newRecord.ObsDefRt = Decimal.Parse(fields[9].Replace("%", ""), NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                    catch (Exception)
                    {
                        newRecord.ObsDefRt = 0;
                    }
                    try
                    {
                        newRecord.CumDef = Convert.ToInt32(fields[10]);
                    }
                    catch (Exception)
                    {
                        newRecord.CumDef = 0;
                    }
                    try
                    {
                        newRecord.CumNdef = Convert.ToInt32(fields[11]);
                    }
                    catch (Exception)
                    {
                        newRecord.CumNdef = 0;
                    }
                    try
                    {
                        newRecord.TotalDef = Convert.ToInt32(fields[12]);
                    }
                    catch (Exception)
                    {
                        newRecord.TotalDef = 0;
                    }
                    try
                    {
                        newRecord.TotalNdef = Convert.ToInt32(fields[13]);
                    }
                    catch (Exception)
                    {
                        newRecord.TotalNdef = 0;
                    }
                    try
                    {
                        newRecord.CumDefRt = Convert.ToInt32(fields[14]);
                    }
                    catch (Exception)
                    {
                        newRecord.CumDefRt = 0;
                    }
                    try
                    {
                        newRecord.CumNdefRt = Convert.ToInt32(fields[15]);
                    }
                    catch (Exception)
                    {
                        newRecord.CumNdefRt = 0;
                    }
                    try
                    {
                        newRecord.KsContri = Decimal.Parse(fields[16].Replace("%", ""), NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    }
                    catch (Exception)
                    {
                        newRecord.KsContri = 0;
                    }

                    await (new PdKsCalculationManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD Monitoring Item.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdMonitoringItem(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdMonitoringItem newRecord = new PdMonitoringItem();
                    newRecord.PeriodEndDate = DateTime.ParseExact(
                        fields[0],
                        ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_IMPORT_DATE_FORMAT],
                        CultureInfo.InvariantCulture);
                    newRecord.AssetSubClass = fields[1];
                    newRecord.SegmentName = fields[2];
                    newRecord.NumberOfAccounts = Convert.ToInt64(fields[3]);
                    newRecord.NumberOfDefaults = Convert.ToInt64(fields[4]);
                    newRecord.LraPd1 = Decimal.Parse(fields[5], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    newRecord.PitPd1 = Decimal.Parse(fields[6], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    newRecord.ActualDefaultRate = Decimal.Parse(fields[7], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new PdMonitoringItemManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD Portfolio Default Rate.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdPortfolioDefaultRate(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdPortfolioDefaultRate newRecord = new PdPortfolioDefaultRate();
                    newRecord.PeriodEndDate = DateTime.ParseExact(
                        fields[0],
                        ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_IMPORT_DATE_FORMAT],
                        CultureInfo.InvariantCulture);
                    newRecord.AssetSubClass = fields[1];
                    newRecord.NumberOfAccounts = Convert.ToInt64(fields[2]);
                    newRecord.NumberOfDefaults = Convert.ToInt64(fields[3]);
                    newRecord.DefaultRate = Decimal.Parse(fields[4], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new PdPortfolioDefaultRateManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD PSI.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdPsi(Stream fileData)
        {
            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdPsi newRecord = new PdPsi();
                    newRecord.PeriodEndDate = DateTime.ParseExact(
                        fields[0],
                        ConfigurationManager.AppSettings[Smart.Constants.ApplicationConstants.APP_SETTINGS_IMPORT_DATE_FORMAT],
                        CultureInfo.InvariantCulture);
                    newRecord.AssetSubClass = fields[1];
                    newRecord.SegmentName = fields[2];
                    newRecord.NumberOfAccounts = Convert.ToInt64(fields[3]);

                    await (new PdPsiManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Imports the data file for PD RWA Summary.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        private async void ImportPdRwaSummary(Stream fileData)
        {
            DateTime periodEndDate = new DateTime(
                Convert.ToInt32(
                    Convert.ToInt64(((FileStream)fileData).Name.Substring(((FileStream)fileData).Name.Length - 10, 4))
                    ),
                Convert.ToInt32(
                    Convert.ToInt64(((FileStream)fileData).Name.Substring(((FileStream)fileData).Name.Length - 6, 2))
                    ),
                1
               ).AddMonths(1).AddDays(-1);

            using (TextFieldParser parser = new TextFieldParser(((FileStream)fileData).Name))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    PdRwaSummary newRecord = new PdRwaSummary();
                    newRecord.PeriodEndDate = periodEndDate;
                    newRecord.SegmentName = fields[0];
                    newRecord.TotalRwa = Decimal.Parse(fields[1], NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                    await (new PdRwaSummaryManager()).InsertRecordAsync(newRecord);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the RadButton1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void RadButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
