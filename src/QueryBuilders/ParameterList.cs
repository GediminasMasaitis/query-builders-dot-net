using System;
using System.Collections.Generic;

namespace QueryBuilders
{
    public class ParameterList : Dictionary<string, QueryParameter>, IParameterList
    {
        private Dictionary<object, string> ReverseLookupTable { get; set; }


        public ParameterList()
        {
            ReverseLookupTable = new Dictionary<object, string>();
        }

        public QueryParameter AddParameter(object value, bool useExisting = true)
        {
            if (value == null)
            {
                value = DBNull.Value;
            }
            if (useExisting && ReverseLookupTable.TryGetValue(value, out var paramName))
            {
                return this[paramName];
            }
            paramName = "@p_" + Count;
            var parameter = new QueryParameter(paramName, value);
            ReverseLookupTable.Add(value, paramName);
            Add(paramName, parameter);
            return parameter;
        }
    }
}