
namespace Be2BillNet
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Be2BillNet.Resources;

    /// <summary>
    /// Utility methods.
    /// </summary>
    public static class Be2BillUtility
    {
        /// <summary>
        /// Gets the display name for execute code.
        /// </summary>
        /// <param name="execCode">The execute code.</param>
        /// <param name="culture">The culture or null.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">The value cannot be empty;execCode</exception>
        public static string GetNameForExecCode(string execCode, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(execCode))
                throw new ArgumentException("The value cannot be empty", "execCode");

            culture = culture ?? CultureInfo.CurrentUICulture ?? CultureInfo.InvariantCulture;

            var message = "ExecCode_" + execCode + "_Name";
            message = Strings.ResourceManager.GetString(message, culture);

            return message;
        }
    }
}
