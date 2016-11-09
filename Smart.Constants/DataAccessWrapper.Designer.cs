﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Smart.Constants {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class DataAccessWrapper {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DataAccessWrapper() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Smart.Constants.DataAccessWrapper", typeof(DataAccessWrapper).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot add parameter. Requires an initialized connection..
        /// </summary>
        internal static string EXCEPTION_MESSAGE_ADD_PARAMETER_FAILURE {
            get {
                return ResourceManager.GetString("EXCEPTION_MESSAGE_ADD_PARAMETER_FAILURE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot create SqlCommand. SqlCommand creation requires initialized connection with connection string..
        /// </summary>
        internal static string EXCEPTION_MESSAGE_CANNOT_CREATE_COMMAND {
            get {
                return ResourceManager.GetString("EXCEPTION_MESSAGE_CANNOT_CREATE_COMMAND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot create SQL Server connection using the specified Connection String specification..
        /// </summary>
        internal static string EXCEPTION_MESSAGE_CANNOT_CREATE_CONNECTION {
            get {
                return ResourceManager.GetString("EXCEPTION_MESSAGE_CANNOT_CREATE_CONNECTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot open a connection to SQL Server. Opening connection to SQL Server requires initialized connection with connection string..
        /// </summary>
        internal static string EXCEPTION_MESSAGE_CANNOT_OPEN_CONNECTION {
            get {
                return ResourceManager.GetString("EXCEPTION_MESSAGE_CANNOT_OPEN_CONNECTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No connection string with name: {0} found in configuration file..
        /// </summary>
        internal static string EXCEPTION_MESSAGE_CONNECTION_STRING_MISSING {
            get {
                return ResourceManager.GetString("EXCEPTION_MESSAGE_CONNECTION_STRING_MISSING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requires an initialized connection..
        /// </summary>
        internal static string EXCEPTION_MESSAGE_REQUIRES_INITIALIZED_CONNECTION {
            get {
                return ResourceManager.GetString("EXCEPTION_MESSAGE_REQUIRES_INITIALIZED_CONNECTION", resourceCulture);
            }
        }
    }
}
