using System;
using System.Text;

namespace QueryBuilders
{
    public class QueryJoin : IBuildable
    {
        public string Table { get; }
        public QueryJoinType JoinType { get; }
        private IParameterList Parameters { get; }
        public CompositeExpression On { get; }

        public QueryJoin(IParameterList parameters, string table, QueryJoinType joinType, QueryLogicOperator logicOperator)
        {
            Table = table;
            JoinType = joinType;
            Parameters = parameters;
            On = new CompositeExpression(parameters, logicOperator);
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
                case QueryJoinType.FullOuter:
                    joinString = "FULL OUTER";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(JoinType), JoinType, null);
            }

            builder.Append(joinString);
            builder.Append(" JOIN ");
            builder.Append(Table);
            builder.Append(" ON ");
            On.BuildInto(builder);
        }
    }
}