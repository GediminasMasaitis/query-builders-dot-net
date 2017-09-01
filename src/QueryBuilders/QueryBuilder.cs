using System.Data;
using System.Text;

namespace QueryBuilders
{
    public abstract class QueryBuilder : IQueryBuilder
    {
        public IParameterList ParameterList { get; }
        public IDbDataParameterFactory DbDataParameterFactory { get; set; }

        public QueryBuilder(IParameterList parameters)
        {
            ParameterList = parameters ?? new ParameterList();
            DbDataParameterFactory = new DbDataParameterFactory();
        }

        public string BuildQuery()
        {
            var builder = new StringBuilder();
            BuildInto(builder);
            return builder.ToString();
        }

        public void PrepareDbCommand(IDbCommand command)
        {
            command.CommandText = BuildQuery();
            foreach (var queryParameter in ParameterList.Values)
            {
                DbDataParameterFactory.AddParameterWithValue(command, queryParameter.Name, queryParameter.Value);
            }
        }

        public abstract void BuildInto(StringBuilder builder);
        
    }
}