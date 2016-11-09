using System.Data.SqlClient;

namespace Smart.DataAccessWrapper
{
    /// <summary>
    /// Interace declaration to assist mapping of raw SQL Row to CLR Object.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Maps raw SQL Row to CLR Object.
        /// </summary>
        /// <typeparam name="T">CLR Class name to map raw SQL Row to.</typeparam>
        /// <param name="reader">Reference for SqlDataReader addressing a single raw row.</param>
        /// <returns>Reference to CLR Object created from raw SQL Row</returns>
        T MapDataToObject<T>(SqlDataReader reader) where T : class, new();
    }
}
