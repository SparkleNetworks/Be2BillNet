
namespace Be2BillNet.AspMvcDemo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Result for a domain request.
    /// Incudes a basic error list and a success boolean.
    /// </summary>
    public class BasicResult
    {
        private IList<BasicResultError> errors;
        private Dictionary<string, object> data;

        /// <summary>
        /// Gets the errors.
        /// </summary>
        public IList<BasicResultError> Errors
        {
            get { return this.errors ?? (this.errors = new List<BasicResultError>()); }
        }

        public Dictionary<string, object> Data
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return this.data ?? (this.data = new Dictionary<string, object>()); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the operation succeeded.
        /// </summary>
        public bool Succeed { get; set; }
    }

    /// <summary>
    /// Result for a domain request.
    /// </summary>
    public class BasicResultError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicResultError"/> class.
        /// </summary>
        /// <param name="displayMessage">The display message.</param>
        public BasicResultError(string displayMessage)
        {
            this.DisplayMessage = displayMessage;
        }

        /// <summary>
        /// Gets or sets the display message.
        /// </summary>
        public string DisplayMessage { get; set; }
    }
}
