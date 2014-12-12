
namespace Be2BillNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// Represents a Be2Bill API error.
    /// </summary>
    [Serializable]
    public class Be2BillApiException : Exception
    {
        private IDictionary<string, object> otherData = new Dictionary<string, object>();

        internal Be2BillApiException(int code)
        {
            this.ErrorCode = code;
        }

        internal Be2BillApiException(int code, string message)
            : base(message)
        {
            this.ErrorCode = code;
        }

        internal Be2BillApiException(int code, string message, Exception inner)
            : base(message, inner)
        {
            this.ErrorCode = code;
        }

        protected Be2BillApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets or sets the internal error code.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets the other data.
        /// </summary>
        public IDictionary<string, object> OtherData
        {
            get { return this.otherData; }
        }

        internal static Be2BillApiException Create(int code, string message, Exception inner, IDictionary<string, object> data, IDictionary<string, object> otherData)
        {
            var ex = new Be2BillApiException(code, message, inner);
            ex.Fill(data, otherData);
            return ex;
        }

        internal void Fill(IDictionary<string, object> data, IDictionary<string, object> otherData)
        {
            if (data != null)
            {
                foreach (var item in data)
                {
                    this.Data[item.Key] = item.Value;
                }
            }

            if (otherData != null)
            {
                foreach (var item in otherData)
                {
                    this.otherData[item.Key] = item.Value;
                }
            }
        }

        public override string ToString()
        {
            var value = base.ToString();
            value = "Be2BillApiException (" + this.ErrorCode + ")" + Environment.NewLine + value;
            return value;
        }
    }
}
