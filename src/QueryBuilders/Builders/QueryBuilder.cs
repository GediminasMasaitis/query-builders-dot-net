using System.Data;
using System.Text;
using QueryBuilders.Buildables;
using QueryBuilders.Interfaces;
using QueryBuilders.Services;

namespace QueryBuilders.Builders
{
    public abstract class QueryBuilder : IQueryBuilder
    {
        public ExplainStatement Explain { get; }
        public IParameterList ParameterList { get; set; }
        public IDbDataParameterFactory DbDataParameterFactory { get; set; }

        public QueryBuilder()
        {
            Explain = new ExplainStatement();
            ParameterList = new ParameterList();
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

        public string Build()
        {
            var sb = new StringBuilder();
            BuildInto(sb);
            var str = sb.ToString();
            return str;
        }

        public void BuildInto(StringBuilder builder)
        {
            var initialLength = builder.Length;
            Explain.BuildInto(builder);
            if (builder.Length > initialLength)
            {
                builder.Append(" ");
            }
            BuildBodyInto(builder);
        }

        public abstract void BuildBodyInto(StringBuilder builder);

        public override string ToString()
        {
            return Build();
        }
    }
}