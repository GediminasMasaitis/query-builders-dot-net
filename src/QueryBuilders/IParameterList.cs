using System.Collections.Generic;

namespace QueryBuilders
{
    public interface IParameterList : IDictionary<string, QueryParameter>
    {
        QueryParameter AddParameter(object value, bool useExisting = true);
    }

    /*public interface IParameterList
    {
        IList<QueryParameter> Parameters { get; }
    }*/
}