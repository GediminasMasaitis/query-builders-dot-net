using System;

namespace QueryBuilders.Exceptions
{
    public class QueryBuildException : Exception
    {
        public QueryBuildException()
        {
        }

        public QueryBuildException(string message) : base(PadMessage(message))
        {
        }

        public QueryBuildException(string message, Exception innerException) : base(PadMessage(message), innerException)
        {
        }

        private static string PadMessage(string message)
        {
            var newMsg = "Query building failed.";
            if (!string.IsNullOrEmpty(message))
            {
                newMsg += " " + message;
            }
            return newMsg;
        }
    }
}