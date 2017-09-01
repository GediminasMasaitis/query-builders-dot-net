using System.Collections.Generic;
using JetBrains.Annotations;
using QueryBuilders.Models;

namespace QueryBuilders.Services
{
    public interface IParameterList : IDictionary<string, QueryParameter>
    {
        QueryParameter AddParameter(object value, bool useExisting = true);
        [StringFormatMethod("statement")]
        string AddParameterString(string statement, params object[] parameters);
    }

    /*public interface IParameterList
    {
        IList<QueryParameter> Parameters { get; }
    }*/
}