using QueryBuilders.Buildables;

namespace QueryBuilders.Interfaces
{
    public interface IHasWhereBuilder
    {
        CompositeExpression Where { get; }
    }
}