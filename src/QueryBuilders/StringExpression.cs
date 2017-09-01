using System.Text;

namespace QueryBuilders
{
    public class StringExpression : IBuildable
    {
        private IParameterList ParameterList { get; }
        public string Statement { get; }
        public QueryParameter[] AssociatedParameters { get; }

        public StringExpression(IParameterList parameterList, string statement, params object[] parameters)
        {
            ParameterList = parameterList;
            AssociatedParameters = new QueryParameter[parameters.Length];
            var paramNames = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = ParameterList.AddParameter(parameters[i]);
                paramNames[i] = parameter.Name;
                AssociatedParameters[i] = parameter;
            }
            Statement = string.Format(statement, paramNames);
        }

        public virtual void BuildInto(StringBuilder builder)
        {
            builder.Append(Statement);
        }
    }
}