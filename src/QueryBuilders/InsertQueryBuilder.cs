using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace QueryBuilders
{
    public class InsertQueryBuilder : QueryBuilder
    {
        public string Table { get; set; }
        public IList<string> FieldNames { get; set; }
        public IDictionary<string, IList<ICompositeEntry<CompositeExpression>>> Entries { get; }
        public SelectQueryBuilder SelectQuery { get; }
        public CompositeExpression Returning { get; }

        public InsertQueryBuilder([NotNull]string table, IParameterList parameters = null) : base(parameters)
        {
            Table = table;
            FieldNames = new List<string>();
            Entries = new Dictionary<string, IList<ICompositeEntry<CompositeExpression>>>();
            SelectQuery = new SelectQueryBuilder(null, ParameterList);
            Returning = new CompositeExpression(ParameterList);
        }

        [StringFormatMethod("statement")]
        public CompositeEntry<CompositeExpression> AddValueExpression(string field, string expression, params object[] parameters)
        {
            var compositeExpression = new CompositeExpression(ParameterList);
            compositeExpression.Add(expression, parameters);
            var compositeEntry = new CompositeEntry<CompositeExpression>(compositeExpression);
            if (!Entries.TryGetValue(field, out var valueList))
            {
                valueList = new List<ICompositeEntry<CompositeExpression>>();
                Entries.Add(field, valueList);
                FieldNames.Add(field);
            }
            valueList.Add(compositeEntry);
            return compositeEntry;
        }

        public CompositeEntry<CompositeExpression> AddValueObject(string field, object value)
        {
            return AddValueExpression(field, "{0}", value);
        }

        public override void BuildInto(StringBuilder builder)
        {
            if (SelectQuery.SelectExpressions.Count == 0 && Entries.Count == 0)
            {
                throw new Exception("Must add either fields or setup a select query");
            }
            if (SelectQuery.SelectExpressions.Count != 0 && Entries.Count != 0)
            {
                throw new Exception("Must add either fields or setup a select query, not both");
            }
            builder.Append("INSERT INTO ");
            builder.Append(Table);
            builder.Append(" (");

            for (var i = 0; i < FieldNames.Count; i++)
            {
                builder.Append(FieldNames[i]);
                if (i < FieldNames.Count - 1)
                {
                    builder.Append(", ");
                }
            }
            builder.Append(") ");

            if (Entries.Count != 0)
            {
                var valueCount = Entries.Values.Max(x => x.Count);
                builder.Append("VALUES ");
                for (int i = 0; i < valueCount; i++)
                {
                    builder.Append("(");
                    for (int j = 0; j < FieldNames.Count; j++)
                    {
                        var values = Entries[FieldNames[j]];
                        var value = values[i];
                        if (value.AddParentheses)
                        {
                            builder.Append("(");
                        }
                        value.Buildable.BuildInto(builder);
                        if (value.AddParentheses)
                        {
                            builder.Append(")");
                        }
                        if (j < FieldNames.Count - 1)
                        {
                            builder.Append(", ");
                        }
                    }
                    builder.Append(")");
                    if (i < valueCount - 1)
                    {
                        builder.Append(", ");
                    }
                }
            }

            if (SelectQuery.SelectExpressions.Count != 0)
            {
                SelectQuery.BuildInto(builder);
            }

            if (Returning.Entries.Count > 0)
            {
                builder.Append(" RETURNING ");
                Returning.BuildInto(builder);
            }
        }
    }
}