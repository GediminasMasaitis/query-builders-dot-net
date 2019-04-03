using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilders.Exceptions;
using QueryBuilders.Interfaces;
using QueryBuilders.Models;
using QueryBuilders.Services;

namespace QueryBuilders.Buildables
{
    public class QueryJoin : IBuildable, IHasUsingsBuilder
    {
        public bool IsEmpty => false;

        public IParameterList Parameters { get; }
        public string Table { get; }
        public bool Natural { get; }
        public QueryJoinType JoinType { get; }
        public CompositeExpression On { get; }
        public IList<string> Usings { get; }

        public QueryJoin(IParameterList parameters, string table, QueryJoinType joinType, QueryLogicOperator logicOperator)
        {
            Table = table;
            Natural = false;
            JoinType = joinType;
            Parameters = parameters;
            On = new CompositeExpression(parameters, logicOperator);
            Usings = new List<string>();
        }

        public void AddUsing(string column)
        {
            Usings.Add(column);
        }

        public void BuildInto(StringBuilder builder)
        {
            string joinString;
            switch (JoinType)
            {
                case QueryJoinType.Inner:
                    joinString = "INNER";
                    break;
                case QueryJoinType.Left:
                    joinString = "LEFT";
                    break;
                case QueryJoinType.Right:
                    joinString = "RIGHT";
                    break;
                case QueryJoinType.Full:
                    joinString = "FULL";
                    break;
                case QueryJoinType.Cross:
                    joinString = "CROSS";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(JoinType), JoinType, null);
            }

            if (JoinType == QueryJoinType.Cross || Natural)
            {
                if (JoinType == QueryJoinType.Cross && Natural)
                {
                    throw new QueryBuildException("Can't use NATURAL with a CROSS JOIN.");
                }
                if (On.Entries.Count != 0)
                {
                    throw new QueryBuildException("Can't use an ON statement with " + (Natural ? "NATURAL." : "a CROSS JOIN."));
                }
                if (Usings.Count != 0)
                {
                    throw new QueryBuildException("Can't use a USING statement with " + (Natural ? "NATURAL." : "a CROSS JOIN."));
                }
                return;
            }
            else if (On.Entries.Count == 0 && Usings.Count == 0)
            {
                throw new QueryBuildException("Must use either a USING statement or an ON statement with " + joinString + " JOIN.");
            }
            if (Natural)
            {
                builder.Append("NATURAL ");
            }
            builder.Append(joinString);
            builder.Append(" JOIN ");
            builder.Append(Table);
            if (On.Entries.Count != 0)
            {
                if (Usings.Count != 0)
                {
                    throw new QueryBuildException("Can't use both an ON statement and a USING statement.");
                }
                builder.Append(" ON ");
                On.BuildInto(builder);
            }
            else
            {
                builder.Append(" USING (");
                for (var i = 0; i < Usings.Count; i++)
                {
                    builder.Append(Usings[i]);
                    if (i != Usings.Count - 1)
                    {
                        builder.Append(", ");
                    }
                }
                builder.Append(")");
            }
        }
    }
}