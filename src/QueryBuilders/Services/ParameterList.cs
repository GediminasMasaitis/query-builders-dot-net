using System;
using System.Collections.Generic;
using QueryBuilders.Models;

namespace QueryBuilders.Services
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

        public string AddParameterString(string statement, params object[] parameters)
        {
            var paramNames = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = AddParameter(parameters[i]);
                paramNames[i] = parameter.Name;
            }
            var formatted = string.Format(statement, paramNames);
            return formatted;
        }
    }
}