﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Be2BillNet.Resources {
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
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Be2BillNet.Resources.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Corresponds to the IDENTIFIER parameter..
        /// </summary>
        internal static string Config_ApiIdentifier_Description {
            get {
                return ResourceManager.GetString("Config_ApiIdentifier_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to API username.
        /// </summary>
        internal static string Config_ApiIdentifier_Name {
            get {
                return ResourceManager.GetString("Config_ApiIdentifier_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Used to sign requests..
        /// </summary>
        internal static string Config_ApiKey_Description {
            get {
                return ResourceManager.GetString("Config_ApiKey_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to API password.
        /// </summary>
        internal static string Config_ApiKey_Name {
            get {
                return ResourceManager.GetString("Config_ApiKey_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The URL to post forms at. Something like https://xxxxxxxx.be2bill.com/front/form/process.php.
        /// </summary>
        internal static string Config_PaymentSubmitUrl_Description {
            get {
                return ResourceManager.GetString("Config_PaymentSubmitUrl_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Payment form URL.
        /// </summary>
        internal static string Config_PaymentSubmitUrl_Name {
            get {
                return ResourceManager.GetString("Config_PaymentSubmitUrl_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Must start with &quot;https://&quot;.
        /// </summary>
        internal static string Config_PaymentSubmitUrl_Regex1 {
            get {
                return ResourceManager.GetString("Config_PaymentSubmitUrl_Regex1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The URL for server-to-server requests. Something like https://xxxxxxxx.be2bill.com/front/service/rest/process.
        /// </summary>
        internal static string Config_RestUrl_Description {
            get {
                return ResourceManager.GetString("Config_RestUrl_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to REST URL.
        /// </summary>
        internal static string Config_RestUrl_Name {
            get {
                return ResourceManager.GetString("Config_RestUrl_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Must start with &quot;https://&quot;.
        /// </summary>
        internal static string Config_RestUrl_Regex1 {
            get {
                return ResourceManager.GetString("Config_RestUrl_Regex1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successful operation.
        /// </summary>
        internal static string ExecCode_0000_Name {
            get {
                return ResourceManager.GetString("ExecCode_0000_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 3D Secure authentication required.
        /// </summary>
        internal static string ExecCode_0001_Name {
            get {
                return ResourceManager.GetString("ExecCode_0001_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Redirection to an alternative means of payment required.
        /// </summary>
        internal static string ExecCode_0002_Name {
            get {
                return ResourceManager.GetString("ExecCode_0002_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing parameter.
        /// </summary>
        internal static string ExecCode_1001_Name {
            get {
                return ResourceManager.GetString("ExecCode_1001_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid parameter.
        /// </summary>
        internal static string ExecCode_1002_Name {
            get {
                return ResourceManager.GetString("ExecCode_1002_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to HASH error.
        /// </summary>
        internal static string ExecCode_1003_Name {
            get {
                return ResourceManager.GetString("ExecCode_1003_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insupported protocol.
        /// </summary>
        internal static string ExecCode_1004_Name {
            get {
                return ResourceManager.GetString("ExecCode_1004_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to REST error.
        /// </summary>
        internal static string ExecCode_1005_Name {
            get {
                return ResourceManager.GetString("ExecCode_1005_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALIAS not found.
        /// </summary>
        internal static string ExecCode_2001_Name {
            get {
                return ResourceManager.GetString("ExecCode_2001_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reference transaction not found.
        /// </summary>
        internal static string ExecCode_2002_Name {
            get {
                return ResourceManager.GetString("ExecCode_2002_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reference transaction not completed.
        /// </summary>
        internal static string ExecCode_2003_Name {
            get {
                return ResourceManager.GetString("ExecCode_2003_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reference transaction not refundable.
        /// </summary>
        internal static string ExecCode_2004_Name {
            get {
                return ResourceManager.GetString("ExecCode_2004_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reference authorization not caputrable.
        /// </summary>
        internal static string ExecCode_2005_Name {
            get {
                return ResourceManager.GetString("ExecCode_2005_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reference transaction not finished.
        /// </summary>
        internal static string ExecCode_2006_Name {
            get {
                return ResourceManager.GetString("ExecCode_2006_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid capture amount.
        /// </summary>
        internal static string ExecCode_2007_Name {
            get {
                return ResourceManager.GetString("ExecCode_2007_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid refund amount.
        /// </summary>
        internal static string ExecCode_2008_Name {
            get {
                return ResourceManager.GetString("ExecCode_2008_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expired authorization.
        /// </summary>
        internal static string ExecCode_2009_Name {
            get {
                return ResourceManager.GetString("ExecCode_2009_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Instalment schedule not found.
        /// </summary>
        internal static string ExecCode_2010_Name {
            get {
                return ResourceManager.GetString("ExecCode_2010_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Instalment schedule already interrupted.
        /// </summary>
        internal static string ExecCode_2011_Name {
            get {
                return ResourceManager.GetString("ExecCode_2011_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Instalment schedule already finished.
        /// </summary>
        internal static string ExecCode_2012_Name {
            get {
                return ResourceManager.GetString("ExecCode_2012_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Disabled account.
        /// </summary>
        internal static string ExecCode_3001_Name {
            get {
                return ResourceManager.GetString("ExecCode_3001_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unauthorized server IP address.
        /// </summary>
        internal static string ExecCode_3002_Name {
            get {
                return ResourceManager.GetString("ExecCode_3002_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unauthorized transaction.
        /// </summary>
        internal static string ExecCode_3003_Name {
            get {
                return ResourceManager.GetString("ExecCode_3003_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction declined by the banking network.
        /// </summary>
        internal static string ExecCode_4001_Name {
            get {
                return ResourceManager.GetString("ExecCode_4001_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Insufficient funds.
        /// </summary>
        internal static string ExecCode_4002_Name {
            get {
                return ResourceManager.GetString("ExecCode_4002_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Card declined by the banking network.
        /// </summary>
        internal static string ExecCode_4003_Name {
            get {
                return ResourceManager.GetString("ExecCode_4003_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Aborted transaction.
        /// </summary>
        internal static string ExecCode_4004_Name {
            get {
                return ResourceManager.GetString("ExecCode_4004_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fraud suspicion.
        /// </summary>
        internal static string ExecCode_4005_Name {
            get {
                return ResourceManager.GetString("ExecCode_4005_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lost card.
        /// </summary>
        internal static string ExecCode_4006_Name {
            get {
                return ResourceManager.GetString("ExecCode_4006_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stolen Card.
        /// </summary>
        internal static string ExecCode_4007_Name {
            get {
                return ResourceManager.GetString("ExecCode_4007_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 3DSecure authentication failed.
        /// </summary>
        internal static string ExecCode_4008_Name {
            get {
                return ResourceManager.GetString("ExecCode_4008_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 3DSecure authentication expired.
        /// </summary>
        internal static string ExecCode_4009_Name {
            get {
                return ResourceManager.GetString("ExecCode_4009_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid transaction.
        /// </summary>
        internal static string ExecCode_4010_Name {
            get {
                return ResourceManager.GetString("ExecCode_4010_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicated transaction.
        /// </summary>
        internal static string ExecCode_4011_Name {
            get {
                return ResourceManager.GetString("ExecCode_4011_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid card data.
        /// </summary>
        internal static string ExecCode_4012_Name {
            get {
                return ResourceManager.GetString("ExecCode_4012_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction declined by banking network for this holder.
        /// </summary>
        internal static string ExecCode_4013_Name {
            get {
                return ResourceManager.GetString("ExecCode_4013_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exchange protocol failure.
        /// </summary>
        internal static string ExecCode_5001_Name {
            get {
                return ResourceManager.GetString("ExecCode_5001_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Banking network error.
        /// </summary>
        internal static string ExecCode_5002_Name {
            get {
                return ResourceManager.GetString("ExecCode_5002_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Time out, the response will be sent to the notification URL.
        /// </summary>
        internal static string ExecCode_5004_Name {
            get {
                return ResourceManager.GetString("ExecCode_5004_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 3D Secure module display error.
        /// </summary>
        internal static string ExecCode_5005_Name {
            get {
                return ResourceManager.GetString("ExecCode_5005_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction declined by the merchant.
        /// </summary>
        internal static string ExecCode_6001_Name {
            get {
                return ResourceManager.GetString("ExecCode_6001_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction declined.
        /// </summary>
        internal static string ExecCode_6002_Name {
            get {
                return ResourceManager.GetString("ExecCode_6002_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The cardholder has already disputed a transaction.
        /// </summary>
        internal static string ExecCode_6003_Name {
            get {
                return ResourceManager.GetString("ExecCode_6003_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction declined by merchant rules.
        /// </summary>
        internal static string ExecCode_6004_Name {
            get {
                return ResourceManager.GetString("ExecCode_6004_Name", resourceCulture);
            }
        }
    }
}
