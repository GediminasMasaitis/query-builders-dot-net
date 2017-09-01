using QueryBuilders.Buildables;

namespace QueryBuilders.Interfaces
{
    public interface IHasExplainBuilder
    {
        ExplainStatement Explain { get; }
    }

}