using System.Text;
using JetBrains.Annotations;
using QueryBuilders.Services;

namespace QueryBuilders.Buildables
{
    public class StringExpression : IBuildable
    {
        public bool IsEmpty => false;

        private IParameterList ParameterList { get; }
        public string Statement { get; }

        [StringFormatMethod("statement")]
        public StringExpression(IParameterList parameterList, string statement, params object[] parameters)
        {
            ParameterList = parameterList;
            Statement = ParameterList.AddParameterString(statement, parameters);
        }

        public virtual void BuildInto(StringBuilder builder)
        {
            builder.Append(Statement);
        }
    }
}