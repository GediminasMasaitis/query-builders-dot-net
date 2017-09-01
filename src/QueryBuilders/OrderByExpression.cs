using System.Text;

namespace QueryBuilders
{
    public class OrderByExpression : StringExpression
    {
        public bool Ascending { get; }

        public OrderByExpression(IParameterList parameterList, string statement, bool ascending, params object[] associatedParameters) : base(parameterList, statement, associatedParameters)
        {
            Ascending = ascending;
        }

        public override void BuildInto(StringBuilder builder)
        {
            base.BuildInto(builder);
            var orderByStr = Ascending ? "ASC" : "DESC";
            builder.Append(' ');
            builder.Append(orderByStr);
        }
    }
}