using System.Reflection;
using System.Resources;

namespace Smart.Constants
{
    /// <summary>
    /// Constant string references used for Data Access Wrapper Library.
    /// </summary>
    public sealed class DataAccessWrapperConstants
    {
        /// <summary>
        /// The resource manager helping for Language Translations.
        /// </summary>
        private static ResourceManager resourceManager = new ResourceManager("Smart.Constants.DataAccessWrapper", Assembly.GetExecutingAssembly());

        /// <summary>
        /// Exception message for missing connection string.
        /// </summary>
        public static string EXCEPTION_MESSAGE_CONNECTION_STRING_MISSING
        {
            get
            {
                return resourceManager.GetString("EXCEPTION_MESSAGE_CONNECTION_STRING_MISSING");
            }
        }

        /// <summary>
        /// Exception message for connection creation failure.
        /// </summary>
        public static string EXCEPTION_MESSAGE_CANNOT_CREATE_CONNECTION
        {
            get
            {
                return resourceManager.GetString("EXCEPTION_MESSAGE_CANNOT_CREATE_CONNECTION");
            }
        }

        /// <summary>
        /// Exception message for command creation failure.
        /// </summary>
        public static string EXCEPTION_MESSAGE_CANNOT_CREATE_COMMAND
        {
            get
            {
                return resourceManager.GetString("EXCEPTION_MESSAGE_CANNOT_CREATE_COMMAND");
            }
        }

        /// <summary>
        /// Exception message for opening connection failure.
        /// </summary>
        public static string EXCEPTION_MESSAGE_CANNOT_OPEN_CONNECTION
        {
            get
            {
                return resourceManager.GetString("EXCEPTION_MESSAGE_CANNOT_OPEN_CONNECTION");
            }
        }

        /// <summary>
        /// Exception message for requiring initialized connection.
        /// </summary>
        public static string EXCEPTION_MESSAGE_REQUIRES_INITIALIZED_CONNECTION
        {
            get
            {
                return resourceManager.GetString("EXCEPTION_MESSAGE_REQUIRES_INITIALIZED_CONNECTION");
            }
        }

        /// <summary>
        /// Exception message for adding parameter failure.
        /// </summary>
        public static string EXCEPTION_MESSAGE_ADD_PARAMETER_FAILURE
        {
            get
            {
                return resourceManager.GetString("EXCEPTION_MESSAGE_ADD_PARAMETER_FAILURE");
            }
        }
    }
}
