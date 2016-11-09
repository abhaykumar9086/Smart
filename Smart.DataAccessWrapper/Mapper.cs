using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Smart.DataAccessWrapper
{
    /// <summary>
    /// Helps in mapping raw SQL Row to CLR Object properties.
    /// </summary>
    /// <seealso cref="Smart.DataAccessWrapper.IMapper" />
    internal class Mapper : IMapper
    {
        #region Private Fields

        /// <summary>
        /// Reference to InstanceCreator class for creating default / singleton instances.
        /// </summary>
        private InstanceCreator instanceCreator = InstanceCreator.Default;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the default / singleton reference for current (Mapper) class.
        /// </summary>
        /// <value>
        /// Singleton reference to current (Mapper) class.
        /// </value>
        public static Mapper Default { get { return Singleton<Mapper>.Instance; } }

        #endregion

        #region Private Methods

        /// <summary>
        /// Finds the properties for a given type.
        /// </summary>
        /// <param name="type">The type for which properties need to be found.</param>
        /// <returns>Dictionary of properties with their Data Type info derived from CLR Object</returns>
        private Dictionary<string, PropertyInfo> FindProperties(Type type)
        {
            var result = new Dictionary<string, PropertyInfo>();

            var propertiesInfos = type.GetProperties().ToList<PropertyInfo>();
            // MapAttribute?
            foreach (var property in propertiesInfos)
            {
                var columnName = property.Name;
                result[columnName] = property;
            }
            return result;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Maps raw SQL Row to CLR Object.
        /// </summary>
        /// <typeparam name="T">CLR Class name to map raw SQL Row to.</typeparam>
        /// <param name="reader">Reference for SqlDataReader addressing a single raw row.</param>
        /// <returns>
        /// Reference to CLR Object created from raw SQL Row
        /// </returns>
        public T MapDataToObject<T>(SqlDataReader reader)
            where T : class, new()
        {
            Type type = typeof(T);

            var properties = FindProperties(type);
            var instance = instanceCreator.CreateInstance(type);
            // parse for each column of current line
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var columnName = reader.GetName(i); // table column name id , name, email ..
                if (properties.ContainsKey(columnName))
                {
                    var property = properties[columnName];
                    var columnValue = reader.IsDBNull(i) ? null : reader.GetValue(i); // column data value
                    var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType; // type of property object "System.String" ...
                    var propertyValue = columnValue == null ? null : Convert.ChangeType(columnValue, propertyType); // convert column value to property value 
                    if (propertyType == typeof(string) && propertyValue != null) propertyValue = propertyValue.ToString().TrimEnd();
                    property.SetValue(instance, propertyValue); // set property value
                }
            }
            return (T)instance;
        }

        #endregion
    }
}
