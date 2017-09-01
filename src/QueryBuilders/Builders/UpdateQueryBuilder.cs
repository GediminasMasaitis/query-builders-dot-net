using System.Collections.Generic;
using System.Text;
using QueryBuilders.Buildables;
using QueryBuilders.Exceptions;
using QueryBuilders.Interfaces;

namespace QueryBuilders.Builders
{
    public class UpdateQueryBuilder : QueryBuilder, IUpdateQueryBuilder
    {
        public string Table { get; set; }
        public bool Only { get; set; }
        public IList<string> FieldNames { get; }
        public IDictionary<string, ICompositeEntry<CompositeExpression>> Entries { get; }
        public IList<string> Froms { get; }
        public CompositeExpression Where { get; }
        public CompositeExpression Returning { get; }

        public UpdateQueryBuilder()
        {
            Only = false;
            FieldNames = new List<string>();
            Entries = new Dictionary<string, ICompositeEntry<CompositeExpression>>();
            Froms = new List<string>();
            Where = new CompositeExpression(ParameterList);
            Returning = new CompositeExpression(ParameterList);
        }

        public void AddFrom(string table)
        {
            Froms.Add(table);
        }

        public ICompositeEntry<CompositeExpression> AddValue(string field, object value)
        {
            return AddValueExpression(field, "{0}", value);
        }

        public ICompositeEntry<CompositeExpression> AddValueExpression(string field, string expression, params object[] parameters)
        {
            var expr = new CompositeExpression(ParameterList);
            expr.Add(field + " = " + expression, parameters);
            var entry = new CompositeEntry<CompositeExpression>(expr);
            FieldNames.Add(field);
            Entries.Add(field, entry);
            return entry;
        }

        public override void BuildBodyInto(StringBuilder builder)
        {
            if (string.IsNullOrEmpty(Table))
            {
                throw new QueryBuildException($"Must assign a table to insert into. Use the {nameof(Table)} property.");
            }
            if (Entries.Count == 0)
            {
                throw new QueryBuildException("Must have at least one value set.");
            }
            builder.Append("UPDATE ");
            if (Only)
            {
                builder.Append("ONLY ");
            }
            builder.Append(Table);
            builder.Append(" SET ");
            for (var i = 0; i < FieldNames.Count; i++)
            {
                var fieldName = FieldNames[i];
                builder.Append(fieldName);
                builder.Append(" = ");
                var entry = Entries[fieldName];
                if (entry.AddParentheses)
                {
                    builder.Append("(");
                }
                entry.Buildable.BuildInto(builder);
                if (entry.AddParentheses)
                {
                    builder.Append(")");
                }
                if (i < FieldNames.Count - 1)
                {
                    builder.Append(", ");
                }
            }
            if (Froms.Count > 0)
            {
                builder.Append(" FROM ");
                for (var i = 0; i < Froms.Count; i++)
                {
                    builder.Append(Froms[i]);
                    if (i < Froms.Count - 1)
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