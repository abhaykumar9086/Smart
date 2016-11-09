using Smart.Basel.DataAccess.DataAccess;
using Smart.Basel.DataAccess.Models;
using System.Threading.Tasks;

namespace Smart.Basel.DataAccess.BusinessObjects
{
    /// <summary>
    /// Provides access to all Database operations needed for BASEL - LGD - Accuracy.
    /// </summary>
    public class LgdAccuracyManager
    {
        #region Public Methods

        /// <summary>
        /// Asynchronously inserts the record.
        /// </summary>
        /// <param name="newRecord">The new record.</param>
        /// <returns>Void Task reference</returns>
        public async Task InsertRecordAsync(LgdAccuracy newRecord)
        {
            await (new LgdAccuracyWriter()).InsertRecordAsync(newRecord);
        }

        #endregion
    }
}
