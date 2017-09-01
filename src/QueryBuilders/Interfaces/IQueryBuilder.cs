using System.Data;
using QueryBuilders.Buildables;
using QueryBuilders.Services;

namespace QueryBuilders.Interfaces
{
    public interface IQueryBuilder : IBuildable, IHasExplainBuilder
    {
        IParameterList ParameterList { get; set; }
        string BuildQuery();
        void PrepareDbCommand(IDbCommand command);
    }
}