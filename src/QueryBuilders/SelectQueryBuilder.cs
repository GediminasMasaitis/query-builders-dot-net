using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilders
{
    public class SelectQueryBuilder : QueryBuilder
    {
        public List<IBuildable> SelectExpressions { get; }
        public List<string> Froms { get; }
        public List<QueryJoin> Joins { get; }
        public CompositeExpression Where { get; }
        public List<IBuildable> GroupByList { get; }
        public CompositeExpression Having { get; }
        public List<IBuildable> OrderByList { get; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }

        public SelectQueryBuilder(string table = null, IParameterList parameters = null) : base(parameters)
        {
            SelectExpressions = new List<IBuildable>();
            Froms = new List<string>();
            Joins = new List<QueryJoin>();
            Where = new CompositeExpression(ParameterList);
            GroupByList = new List<IBuildable>();
            Having = new CompositeExpression(ParameterList);
            OrderByList = new List<IBuildable>();
            Limit = null;
            Offset = null;
            if (table != null)
            {
                AddFrom(table);
            }
        }

        public void AddFrom(string table)
        {
            Froms.Add(table);
        }

        public QueryJoin AddJoin(string table, QueryJoinType joinType = QueryJoinType.Inner)
        {
            var join = new QueryJoin(ParameterList, table, joinType, QueryLogicOperator.And);
            Joins.Add(join);
            return join;
        }

        public void AddField(string field)
        {
            var expr = new StringExpression(ParameterList, field);
            SelectExpressions.Add(expr);
        }

        public void AddOrderBy(string statement, bool ascending)
        {
            var expr = new OrderByExpression(ParameterList, statement, ascending);
            OrderByList.Add(expr);
        }

        public override void BuildInto(StringBuilder builder)
        {
            if (SelectExpressions.Count == 0)
            {
                throw new Exception("You must select something");
            }
            builder.Append("SELECT ");
            for (var i = 0; i < SelectExpressions.Count; i++)
            {
                var expr = SelectExpressions[i];
                expr.BuildInto(builder);
                if (i < SelectExpressions.Count - 1)
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
            else if (Joins.Count > 0)
            {
                throw new Exception("Can't join without specifying at least one FROM table");
            }
            for (var i = 0; i < Joins.Count; i++)
            {
                builder.Append(' ');
                Joins[i].BuildInto(builder);
            }
            
            if (Where.Entries.Count > 0)
            {
                builder.Append(" WHERE ");
                Where.BuildInto(builder);
            }

            if (GroupByList.Count > 0)
            {
                builder.Append(" GROUP BY ");
                for (var i = 0; i < GroupByList.Count; i++)
                {
                    GroupByList[i].BuildInto(builder);
                    if (i < GroupByList.Count - 1)
                    {
                        builder.Append(", ");
                    }
                }
            }

            if (Having.Entries.Count > 0)
            {
                builder.Append(" HAVING ");
                Having.BuildInto(builder);
            }

            if (OrderByList.Count > 0)
            {
                builder.Append(" ORDER BY ");
                for (var i = 0; i < OrderByList.Count; i++)
                {
                    OrderByList[i].BuildInto(builder);
                    if (i < OrderByList.Count - 1)
                    {
                        builder.Append(", ");
                    }
                }
            }

            if (Limit.HasValue)
            {
                builder.Append(" LIMIT " + Limit.Value);
            }

            if (Offset.HasValue)
            {
                builder.Append(" OFFSET " + Offset.Value);
            }
        }
    }
}