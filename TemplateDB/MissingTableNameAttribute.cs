using System;
using System.Runtime.Serialization;

namespace TemplatePr
{
    [Serializable]
    internal class MissingTableNameAttribute : Exception
    {
        public MissingTableNameAttribute()
        {
        }

        public MissingTableNameAttribute(string message) : base(message)
        {
        }

        public MissingTableNameAttribute(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingTableNameAttribute(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}