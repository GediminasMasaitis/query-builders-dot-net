using System.Collections.Generic;
using System.Text;
using QueryBuilders.Buildables;
using QueryBuilders.Exceptions;
using QueryBuilders.Interfaces;

namespace QueryBuilders.Builders
{
    public class DeleteQueryBuilder : QueryBuilder, IDeleteQueryBuilder
    {
        public string Table { get; set; }
        public bool Only { get; set; }
        public IList<string> Usings { get; }
        public CompositeExpression Where { get; }
        public CompositeExpression Returning { get; }

        public DeleteQueryBuilder()
        {
            Only = false;
            Usings = new List<string>();
            Where = new CompositeExpression(ParameterList);
            Returning = new CompositeExpression(ParameterList);
        }

        public void AddUsing(string table)
        {
            Usings.Add(table);
        }

        public override void BuildBodyInto(StringBuilder builder)
        {
            if (string.IsNullOrEmpty(Table))
            {
                throw new QueryBuildException($"Must assign a table to insert into. Use the {nameof(Table)} property.");
            }
            builder.Append("DELETE FROM ");
            if (Only)
            {
                builder.Append("ONLY ");
            }
            builder.Append(Table);
            if (Usings.Count > 0)
            {
                builder.Append(" USING ");
                for (var i = 0; i < Usings.Count; i++)
                {
                    builder.Append(Usings[i]);
                    if (i < Usings.Count - 1)
                    {
                        builder.Append(", ");
                    }
                }
            }

            if (Where.Entries.Count > 0)
            {
                builder.Append(" WHERE ");
                Where.BuildInto(builder);
            }

            if (Returning.Entries.Count > 0)
            {
                builder.Append(" RETURNING ");
                Returning.BuildInto(builder);
            }
        }
    }
}