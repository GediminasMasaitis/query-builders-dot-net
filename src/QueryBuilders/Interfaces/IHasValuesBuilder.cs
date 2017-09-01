using QueryBuilders.Buildables;

namespace QueryBuilders.Interfaces
{
    public interface IHasValuesBuilder
    {
        ICompositeEntry<CompositeExpression> AddValue(string field, object value);
        ICompositeEntry<CompositeExpression> AddValueExpression(string field, string expression, params object[] parameters);
    }
}