using System.Data;

namespace QueryBuilders
{
    public interface IQueryBuilder : IBuildable
    {
        string BuildQuery();
        void PrepareDbCommand(IDbCommand command);
    }
}