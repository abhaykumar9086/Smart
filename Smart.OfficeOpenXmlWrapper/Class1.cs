using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NotesFor.HtmlToOpenXml;
using System;
using System.Linq;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.IO;

namespace Smart.OfficeOpenXmlWrapper
{
    public class Class1
    {
        public static bool LoadTable(string filePath, string tableCaption, System.Data.DataTable tableRows)
        {
            // If there are no rows to be managed, exit from the function.
            if (tableRows.Rows.Count == 0)
            {
                return true;
            }

            // Check if file exists or not.
            if (!File.Exists(filePath))
            {
                return false;
            }

            // Load file via DocX wrapper.
            Novacode.DocX document = Novacode.DocX.Load(filePath);

            // Try to get the table with the requested caption.
            var targetTable = document.Tables.Where(r => r.TableCaption == tableCaption).FirstOrDefault();

            // If table does not exist, simply exit from the function.
            if (targetTable == null)
            {
                document.Dispose();
                return false;
            }

            // Table should always have two rows - Header and a single data row. 
            // If header row does not exist, exit from the function.
            if (targetTable.Rows.Count != 2)
            {
                document.Dispose();
                return false;
            }

            // Try to get Border styles from the Data row. Typically, they remain same.
            var borderBottom = targetTable.Rows[1].Cells[0].GetBorder(Novacode.TableCellBorderType.Bottom);
            var borderLeft = targetTable.Rows[1].Cells[0].GetBorder(Novacode.TableCellBorderType.Left);
            var borderRight = targetTable.Rows[1].Cells[0].GetBorder(Novacode.TableCellBorderType.Right);
            var borderTop = targetTable.Rows[1].Cells[0].GetBorder(Novacode.TableCellBorderType.Top);

            // Load first DataTable row.
            for (int ctr = 0; ctr < targetTable.Rows[1].ColumnCount; ctr++)
            {
                string existingText = targetTable.Rows[1].Cells[ctr].Paragraphs[0].Text;
                targetTable.Rows[1].Cells[ctr].Paragraphs[0].ReplaceText(existingText, tableRows.Rows[1][ctr].ToString());
            }

            for (int ctr1 = 1; ctr1 < tableRows.Rows.Count; ctr1++)
            {
                // Create a new blank row.
                Novacode.Row newRow = targetTable.InsertRow();

                for (int ctr2 = 0; ctr2 < targetTable.Rows[1].ColumnCount; ctr2++)
                {
                    string existingText = targetTable.Rows[1].Cells[ctr].Paragraphs[0].Text;
                    targetTable.Rows[1].Cells[ctr].Paragraphs[0].ReplaceText(existingText, tableRows.Rows[1][ctr].ToString());
                }
            }

            try
            {
                document.Paragraphs.Where(r => r.Text == "Table 1.1: Threshold Table").ToArray()[0].ReplaceText("Table 1.1: Threshold Table", "sa");
                document.Save();
            }
            catch (Exception)
            {

            }

            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[0].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[0].Paragraphs.First().Append("Sanket\rTarun\rShah\rTesting\rRepeat\rHeader");
            newRow.Cells[0].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[0].Paragraphs[0].Bold();
            newRow.Cells[0].Paragraphs[0].Italic();
            newRow.Cells[0].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[0].Paragraphs[0].FontSize(9);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[1].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[1].Paragraphs.First().Append("Tarun");
            newRow.Cells[1].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[1].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[1].Paragraphs[0].FontSize(9);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[2].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[2].Paragraphs.First().Append("Shah");
            newRow.Cells[2].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[2].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[2].Paragraphs[0].FontSize(9);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            targetTable.Rows.Add(newRow);


            newRow = targetTable.InsertRow();

            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[0].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[0].Paragraphs.First().Append("Nirali");
            newRow.Cells[0].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[0].Paragraphs[0].Bold();
            newRow.Cells[0].Paragraphs[0].Italic();
            newRow.Cells[0].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[0].Paragraphs[0].FontSize(9);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[1].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[1].Paragraphs.First().Append("Sanket");
            newRow.Cells[1].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[1].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[1].Paragraphs[0].FontSize(9);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[2].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[2].Paragraphs.First().Append("Shah");
            newRow.Cells[2].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[2].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[2].Paragraphs[0].FontSize(9);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            targetTable.Rows.Add(newRow);


            newRow = targetTable.InsertRow();

            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[0].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[0].Paragraphs.First().Append("Tarun");
            newRow.Cells[0].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[0].Paragraphs[0].Bold();
            newRow.Cells[0].Paragraphs[0].Italic();
            newRow.Cells[0].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[0].Paragraphs[0].FontSize(9);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[1].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[1].Paragraphs.First().Append("Ramanlal");
            newRow.Cells[1].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[1].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[1].Paragraphs[0].FontSize(9);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[2].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[2].Paragraphs.First().Append("Shah");
            newRow.Cells[2].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[2].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[2].Paragraphs[0].FontSize(9);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            targetTable.Rows.Add(newRow);


            newRow = targetTable.InsertRow();

            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[0].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[0].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[0].Paragraphs.First().Append("Jagruti");
            newRow.Cells[0].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[0].Paragraphs[0].Bold();
            newRow.Cells[0].Paragraphs[0].Italic();
            newRow.Cells[0].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[0].Paragraphs[0].FontSize(9);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[0].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[1].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[1].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[1].Paragraphs.First().Append("Tarun");
            newRow.Cells[1].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[1].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[1].Paragraphs[0].FontSize(9);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[1].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Bottom, borderBottom);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Left, borderLeft);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Right, borderRight);
            newRow.Cells[2].SetBorder(Novacode.TableCellBorderType.Top, borderTop);
            newRow.Cells[2].VerticalAlignment = Novacode.VerticalAlignment.Center;
            newRow.Cells[2].Paragraphs.First().Append("Shah");
            newRow.Cells[2].Paragraphs[0].Alignment = Novacode.Alignment.center;
            newRow.Cells[2].Paragraphs[0].Font(new System.Drawing.FontFamily("Calibri"));
            newRow.Cells[2].Paragraphs[0].FontSize(9);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Before, 0);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.After, 0);
            newRow.Cells[2].Paragraphs[0].SetLineSpacing(Novacode.LineSpacingType.Line, 1);

            targetTable.Rows.Add(newRow);

            document.Save();
        }
    }
}
