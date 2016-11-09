using System;
using System.Linq;
using System.Reflection;

namespace Smart.DataAccessWrapper
{
    /// <summary>
    /// Helper class to create singleton instance.
    /// </summary>
    internal class InstanceCreator
    {
        #region Public Properties

        /// <summary>
        /// Gets the singleton instance for the type specified.
        /// </summary>
        /// <value>
        /// Single instance for the type specified.
        /// </value>
        public static InstanceCreator Default { get { return Singleton<InstanceCreator>.Instance; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the constructor information for given type.
        /// </summary>
        /// <param name="type">The type for which constructor information needs to be determined.</param>
        /// <returns>Reference to first constructor</returns>
        public virtual ConstructorInfo GetConstructorInfo(Type type)
        {
            var constructors = type.GetTypeInfo().DeclaredConstructors;

            return constructors.FirstOrDefault(c => c.Name != ".cctor");
        }

        /// <summary>
        /// Creates the instance for the specified type.
        /// </summary>
        /// <param name="type">The type for which instance needs to be created.</param>
        /// <returns>Reference to instance for the specified type</returns>
        public object CreateInstance(Type type)
        {
            var constructorInfo = GetConstructorInfo(type);
            var parameterInfos = constructorInfo.GetParameters();

            if (parameterInfos.Length == 0)
            {
                return Activator.CreateInstance(type);
            }
            else
            {
                var parameters = new object[parameterInfos.Length];

                foreach (var parameterInfo in parameterInfos)
                {
                    parameters[parameterInfo.Position] = CreateInstance(parameterInfo.ParameterType);
                }

                return Activator.CreateInstance(type, parameters);
            }
        } 
 
        #endregion
    }
}
