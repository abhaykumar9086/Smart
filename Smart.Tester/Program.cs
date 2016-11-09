using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smart.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");

            Console.WriteLine(
                string.Format(
                Smart.Constants.DataAccessWrapperConstants.EXCEPTION_MESSAGE_CONNECTION_STRING_MISSING, "Sa"));

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");

            Console.WriteLine(
                string.Format(
                Smart.Constants.DataAccessWrapperConstants.EXCEPTION_MESSAGE_CONNECTION_STRING_MISSING, "Sa"));

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Console.WriteLine(
                string.Format(
                Smart.Constants.DataAccessWrapperConstants.EXCEPTION_MESSAGE_CONNECTION_STRING_MISSING, "Malhar"));
        }
    }
}
