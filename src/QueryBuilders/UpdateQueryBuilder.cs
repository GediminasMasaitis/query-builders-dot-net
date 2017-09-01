using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace QueryBuilders
{
    public class UpdateQueryBuilder : QueryBuilder
    {
        public string Table { get; set; }
        public bool Only { get; set; }
        public List<CompositeExpression> Sets { get; }
        public List<string> Froms { get; }
        public CompositeExpression Where { get; }
        public CompositeExpression Returning { get; }

        public UpdateQueryBuilder([NotNull]string table, IParameterList parameters = null) : base(parameters)
        {
            Table = table;
            Only = false;
            Sets = new List<CompositeExpression>();
            Froms = new List<string>();
            Where = new CompositeExpression(ParameterList);
            Returning = new CompositeExpression(ParameterList);
        }

        public void AddFrom(string table)
        {
            Froms.Add(table);
        }

        public CompositeExpression AddSetObject(string field, object value)
        {
            return AddSetExpression(field, "{0}", value);
        }

        public CompositeExpression AddSetExpression(string field, string expression, params object[] parameters)
        {
            var expr = new CompositeExpression(ParameterList);
            expr.Add(field + " = " + expression, parameters);
            Sets.Add(expr);
            return expr;
        }

        public override void BuildInto(StringBuilder builder)
        {
            if (Sets.Count == 0)
            {
                throw new Exception("You must set something");
            }
            builder.Append("UPDATE ");
            if (Only)
            {
                builder.Append("ONLY ");
            }
            builder.Append(Table);
            builder.Append(" SET ");
            for (var i = 0; i < Sets.Count; i++)
            {
                var expr = Sets[i];
                expr.BuildInto(builder);
                if (i < Sets.Count - 1)
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