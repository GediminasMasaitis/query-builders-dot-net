using QueryBuilders.Buildables;

namespace QueryBuilders.Interfaces
{
    public interface IHasReturningBuilder
    {
        CompositeExpression Returning { get; }
    }
}